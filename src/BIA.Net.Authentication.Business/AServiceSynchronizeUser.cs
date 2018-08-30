﻿namespace BIA.Net.Authentication.Business
{
    using BIA.Net.Authentication.Business.Helpers;
    using BIA.Net.Common;
    using BIA.Net.Common.Helpers;
    using System;
    using System.Collections.Generic;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;

    public abstract class AServiceSynchronizeUser : IDisposable
    {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="System.Exception">Please overide Dispose</exception>
        public virtual void Dispose()
        {
            throw new Exception("Please overide Dispose");
        }

        /// <summary>
        /// Gets the name of the ASP net user by.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>Nothing: Function to override</returns>
        /// <exception cref="System.Exception">Please overide GetUserPropertiesByName</exception>
        public virtual IUserProperties GetUserPropertiesByName(string userName)
        {
            throw new Exception("Please overide GetUserPropertiesByName");
        }

        /// <summary>
        /// Resets the dai enable.
        /// </summary>
        /// <param name="userProperties">The ASP net user.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns>Nothing: Function to override</returns>
        /// <exception cref="System.Exception">Please overide SetUserValidity</exception>
        public virtual ILinkedUserProperties SetUserValidity(ILinkedUserProperties userProperties, bool value)
        {
            throw new Exception("Please overide SetUserValidity");
        }

        /// <summary>
        /// Synchronizes all user.
        /// </summary>
        /// <param name="adGroupsAsApplicationUsers">List of ad groups</param>
        /// <typeparam name="TLinkedUserProperties">The type of the user DB table DTO.</typeparam>
        /// <returns>List of user deleted</returns>
        public virtual List<string> SynchronizeUsers<TUserInfo, TUserProperties, TLinkedUserProperties>(List<ADGroup> adGroupsAsApplicationUsers)
               where TLinkedUserProperties : ILinkedUserProperties, new()
               where TUserInfo : AUserInfo<TUserProperties>, new()
               where TUserProperties : IUserProperties, new()
        {
            List<string> listUserInGroup = new List<string>();
            List<ILinkedUserProperties> listUserName = GetAllUsersInDB();
            foreach (ADGroup group in adGroupsAsApplicationUsers)
            {
                List<UserPrincipal> listUsers = group.GetAllUsersInGroup();

                foreach (UserPrincipal user in listUsers)
                {
                    string userName = ADHelper.GetUserName(user);
                    listUserInGroup.Add(userName);
                    ILinkedUserProperties findedUser = listUserName.Where(a => a.BusinessID == userName).FirstOrDefault();

                    if (findedUser == null)
                    {
                        TUserInfo userInfo = new TUserInfo();
                        userInfo.Identities = new Dictionary<string, string>() { { "Login", userName } };
                        userInfo.BaseRefreshProperties();
                        // Create the missing user

                        ILinkedUserProperties adUserCreated = Insert(userInfo.Properties.LinkedUserProperties);
                        listUserName.Add(new TLinkedUserProperties { BusinessID = userName, IsValid = true });
                    }
                    else if (findedUser.IsValid == false)
                    {
                        findedUser.IsValid = true;
                        ILinkedUserProperties updatedUserProperties = SetUserValidity(findedUser, true);
                    }
                }
            }

            List<string> usersDeleted = new List<string>();

            // check users to unactive
            foreach (TLinkedUserProperties userProperties in listUserName)
            {
                if (!listUserInGroup.Contains(userProperties.BusinessID) && userProperties.IsValid == true)
                {
                    usersDeleted.Add(userProperties.BusinessID);
                    userProperties.IsValid = false;
                    ILinkedUserProperties updatedUserProperties = SetUserValidity(userProperties, false);
                }
            }

            return usersDeleted;
        }

        /// <summary>
        /// Inserts the specified ASP user.
        /// </summary>
        /// <param name="aspUser">The ASP user.</param>
        /// <returns>Nothing: Function to override</returns>
        /// <exception cref="System.Exception">Please overide Insert</exception>
        protected virtual ILinkedUserProperties Insert(ILinkedUserProperties aspUser)
        {
            throw new Exception("Please overide Insert");
        }

        /// <summary>
        /// Gets all users in database.
        /// </summary>
        /// <returns>Nothing: Function to override</returns>
        /// <exception cref="System.Exception">Please overide GetAllUsersInDB</exception>
        protected virtual List<ILinkedUserProperties> GetAllUsersInDB()
        {
            throw new Exception("Please overide GetAllUsersInDB");
        }
    }
}