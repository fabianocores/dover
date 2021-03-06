﻿/*
 *  Dover Framework - OpenSource Development framework for SAP Business One
 *  Copyright (C) 2014  Eduardo Piva
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 *  Contact me at <efpiva@gmail.com>
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dover.Framework.Attribute
{
    public enum ResourceType
    {
        UserField,
        UserTable,
        UDO
    }

    /// <summary>
    /// Include a resource on the AddInProject. All resources will be installed by Dover
    /// on AddIn Install.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public class ResourceBOMAttribute : System.Attribute, IComparable<ResourceBOMAttribute>
    {
        /// <summary>
        /// Fully Qualified Name of the embedded resource
        /// </summary>
        public String ResourceName;
        /// <summary>
        /// Type of the resource
        /// </summary>
        public ResourceType Type;

        /// <summary>
        /// Include a resource on the AddInProject. All resources will be installed by Dover
        /// on AddIn Install.
        /// </summary>
        /// <param name="ResourceName">
        /// Fully Qualified Name of the embedded resource
        /// </param>
        /// <param name="Type">
        /// Type of the resource
        /// </param>
        public ResourceBOMAttribute(String ResourceName, ResourceType Type)
        {
            this.ResourceName = ResourceName;
            this.Type = Type;
        }

        public override string ToString()
        {
            return String.Format("[ResourceName={0} ; Type = {1}]", ResourceName, Type);
        }

        int IComparable<ResourceBOMAttribute>.CompareTo(ResourceBOMAttribute other)
        {
            if (this.Type == other.Type)
                return ResourceName.CompareTo(other.ResourceName);

            if (this.Type == ResourceType.UserTable)
                return -1;

            if (this.Type == ResourceType.UserField && other.Type == ResourceType.UDO)
                return -1;

            return 1;
        }
    }
}
