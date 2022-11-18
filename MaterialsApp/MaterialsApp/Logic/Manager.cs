using MaterialsApp.Data;
using MaterialsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsApp.Logic
{
    public class Manager
    {
        private IDataSource IDataSource { get; set; }

        public Manager(IDataSource dataSource)
        {
            IDataSource = dataSource;
        }

        public WorkflowResponse CheckResources(string username)
        {
            User user = IDataSource.Authenticate(username);
            WorkflowResponse response = new WorkflowResponse();

            if (user == null)
            {
                response.Success = false;
                response.Message = $"Error: user {username} not found. Press any key to return to the main menu... ";
            }
            else
            {
                User userToCheck = IDataSource.GetUser(user);

                response.Success = true;
                response.User = userToCheck;
            }

            return response;
        }

        public WorkflowResponse DepositResource(string username, ResourceType resource, int depositAmount)
        {
            User user = IDataSource.Authenticate(username);
            WorkflowResponse response = new WorkflowResponse();

            if (user == null)
            {
                response.Success = false;
                response.Message = $"Error: user {username} not found. Press any key to return to the main menu... ";
            }
            else if (resource == ResourceType.Invalid)
            {
                response.Success = false;
                response.Message = "Error: resource type selection was not valid. Press any key to return to the main menu...";
            }
            else if (depositAmount <= 0)
            {
                response.Success = false;
                response.Message = "Error: resouce amount must be an integer greater than 0. Press any key to return to the main menu...";
            }
            else
            {
                RouteDeposit(user, resource, depositAmount);
                response.Success = true;
                response.Message = $"Successfully deposited {depositAmount} {resource} into the account. Press any key to return to the main menu...";
            }

            return response;
        }

        public WorkflowResponse WithdrawResource(string username, ResourceType resource, int withdrawAmount)
        {
            User user = IDataSource.Authenticate(username);
            WorkflowResponse response = new WorkflowResponse();

            if (user == null)
            {
                response.Success = false;
                response.Message = $"Error: user {username} not found. Press any key to return to the main menu... ";
            }
            else if (resource == ResourceType.Invalid)
            {
                response.Success = false;
                response.Message = "Error: resource type selection was not valid. Press any key to return to the main menu...";
            }
            else if (withdrawAmount <= 0)
            {
                response.Success = false;
                response.Message = "Error: resouce amount must be an integer greater than 0. Press any key to return to the main menu...";
            }
            else if (GetResourceAmount(resource, user) < withdrawAmount)
            {
                response.Success = false;
                response.Message = $"Error: insufficient balance of {resource}";
            }
            else
            {
                RouteWithdraw(user, resource, withdrawAmount);
                response.Success = true;
                response.Message = $"Successfully withdrew {withdrawAmount} {resource} from account. Press any key to return to the main menu...";
            }

            return response;
        }

        private int GetResourceAmount(ResourceType resource, User user)
        {
            switch (resource)
            {
                case ResourceType.Gold:
                    return user.GoldCount;

                case ResourceType.Iron:
                    return user.IronCount;

                case ResourceType.Stone:
                    return user.StoneCount;

                case ResourceType.Wood:
                    return user.WoodCount;
                
                default:
                    throw new Exception("Error in routing resource type in GetResourceAmount");
            }
        }

        private void RouteDeposit(User user, ResourceType resource, int depositAmount)
        {
            switch (resource)
            {
                case ResourceType.Gold:
                    IDataSource.DepositGold(user, depositAmount);
                    break;

                case ResourceType.Iron:
                    IDataSource.DepositIron(user, depositAmount);
                    break;

                case ResourceType.Stone:
                    IDataSource.DepositStone(user, depositAmount);
                    break;

                case ResourceType.Wood:
                    IDataSource.DepositWood(user, depositAmount);
                    break;

                default:
                    throw new Exception("Error: RouteDeposit unable to route deposit request.");
            }
        }

        private void RouteWithdraw(User user, ResourceType resource, int withdrawAmount)
        {
            switch (resource)
            {
                case ResourceType.Gold:
                    IDataSource.WithdrawGold(user, withdrawAmount);
                    break;

                case ResourceType.Iron:
                    IDataSource.WithdrawIron(user, withdrawAmount);
                    break;

                case ResourceType.Stone:
                    IDataSource.WithdrawStone(user, withdrawAmount);
                    break;

                case ResourceType.Wood:
                    IDataSource.WithdrawWood(user, withdrawAmount);
                    break;

                default:
                    throw new Exception("Error: RouteDeposit unable to route deposit request.");
            }
        }
    }
}
