﻿// <copyright file="BIASettingsReader.cs" company="BIA.NET">
// Copyright (c) BIA.NET. All rights reserved.
// </copyright>

namespace BIA.Net.Common
{
    using BIA.Net.Common.Configuration;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Linq;
    using static BIA.Net.Common.Configuration.CommonElement;

    /// <summary>
    /// AppSettings Reader
    /// </summary>
    public static class BIASettingsReader
    {
        private static Dictionary<string, string> dialogLayouts = null;

        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<string, string> DialogLayouts
        {
            get
            {
                if (dialogLayouts == null)
                {
                    dialogLayouts = new Dictionary<string, string>();
                    BIANetSection section = (BIANetSection)ConfigurationManager.GetSection("BiaNet");
                    LayoutsCollection layouts = section?.Dialog?.Layouts;
                    if (layouts != null)
                    {
                        foreach (LayoutElement layout in layouts)
                        {
                            dialogLayouts.Add(layout.Name, layout.Path);
                        }
                    }
                }
                return dialogLayouts;
            }
        }

        private static BIANetSection biaNetSection = null;

        /// <summary>
        /// Get the BIANe Section
        /// </summary>
        public static BIANetSection BIANetSection
        {
            get
            {
                if (biaNetSection == null)
                {
                        biaNetSection = (BIANetSection)ConfigurationManager.GetSection("BiaNet");
                }
                return biaNetSection;
            }
        }

        /// <summary>
        /// Gets AD Groups As Application Users
        /// </summary>
        public static string GetDialogLayout(string name)
        {
            string value = null;
            if (DialogLayouts.TryGetValue(name, out value))
            {
                return value;
            }

            return null;
        }


        /*

        /// <summary>

        private static Dictionary<string, List<string>> adRoles = null;
        public static Dictionary<string, List<string>> ADRoles
        {
            get
            {
                if (adRoles == null)
                {
                    adRoles = new Dictionary<string, List<string>>();
                    KeyValueCollection ADRolesCollection = BIASettingsReader.BIANetSection?.Authentication?.Roles?.AD;
                    if (ADRolesCollection != null && ADRolesCollection.Count>0)
                    {
                        foreach (KeyValueElement role in ADRolesCollection)
                        {
                            List<string> values = new List<string>(role.Value.Split(',')).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                            if (values != null && values.Any())
                            {
                                adRoles.Add(role.Key, values);
                            }
                        }
                    }
                }
                return adRoles;
            }
        }

        /// <summary>
        /// Gets AD Groups As Application Users
        /// </summary>
        public static List<string> GetADGroupsForRole(string role)
        {
            List<string> value = null;
            if (ADRoles.TryGetValue(role, out value))
            {
                return value;
            }

            return null;
        }
        */

        /// <summary>
        /// Gets AD Simulated User
        /// </summary>
        public static string UrlIndexDivision
        {
            get
            {
                return ConfigurationManager.AppSettings["UrlIndexDivision"];
            }
        }

        /// <summary>
        /// Gets AD Simulated User
        /// </summary>
        public static bool DisableUserGroupCheck
        {
            get
            {
                string value = ConfigurationManager.AppSettings["DisableUserGroupCheck"];
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }
                if (value.ToLower() == "true") return true;
                return false;
            }
        }

        /// <summary>
        /// Gets Static URL for resources.
        /// </summary>
        public static string UrlStatic
        {
            get
            {
                return ConfigurationManager.AppSettings["UrlStatic"];
            }
        }

        /// <summary>
        /// Gets the company name.
        /// </summary>
        public static string CompanyName
        {
            get
            {
                return ConfigurationManager.AppSettings["CompanyName"];
            }
        }
        /// <summary>
        /// Gets the division name.
        /// </summary>
        public static string DivisionName
        {
            get
            {
                return ConfigurationManager.AppSettings["DivisionName"];
            }
        }

        /// <summary>
        /// Gets the project title.
        /// </summary>
        public static string ProjectTitle
        {
            get
            {
                return ConfigurationManager.AppSettings["ProjectTitle"];
            }
        }

        /// <summary>
        /// Gets the project short name.
        /// </summary>
        public static string ProjectShortName
        {
            get
            {
                return ConfigurationManager.AppSettings["ProjectShortName"];
            }
        }
    }
}