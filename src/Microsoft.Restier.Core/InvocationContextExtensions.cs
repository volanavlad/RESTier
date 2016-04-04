﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
 
namespace Microsoft.Restier.Core
{
    /// <summary>
    /// Represents the API engine and provides a set of static
    /// (Shared in Visual Basic) methods for interacting with objects
    /// that implement <see cref="InvocationContext"/>.
    /// </summary>
    public static class InvocationContextExtensions
    {
        #region PropertyBag

        /// <summary>
        /// Indicates if this object has a property.
        /// </summary>
        /// <param name="context">
        /// An invocation context.
        /// </param>
        /// <param name="name">
        /// The name of a property.
        /// </param>
        /// <returns>
        /// <c>true</c> if this object has the
        /// property; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasProperty(this InvocationContext context, string name)
        {
            return context.GetPropertyBag().HasProperty(name);
        }

        /// <summary>
        /// Gets a property.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the property.
        /// </typeparam>
        /// <param name="context">
        /// An invocation context.
        /// </param>
        /// <param name="name">
        /// The name of a property.
        /// </param>
        /// <returns>
        /// The value of the property.
        /// </returns>
        public static T GetProperty<T>(this InvocationContext context, string name)
        {
            return context.GetPropertyBag().GetProperty<T>(name);
        }

        /// <summary>
        /// Gets a property.
        /// </summary>
        /// <param name="context">
        /// An invocation context.
        /// </param>
        /// <param name="name">
        /// The name of a property.
        /// </param>
        /// <returns>
        /// The value of the property.
        /// </returns>
        public static object GetProperty(this InvocationContext context, string name)
        {
            return context.GetPropertyBag().GetProperty(name);
        }

        /// <summary>
        /// Sets a property.
        /// </summary>
        /// <param name="context">
        /// An invocation context.
        /// </param>
        /// <param name="name">
        /// The name of a property.
        /// </param>
        /// <param name="value">
        /// A value for the property.
        /// </param>
        public static void SetProperty(this InvocationContext context, string name, object value)
        {
            context.GetPropertyBag().SetProperty(name, value);
        }

        /// <summary>
        /// Clears a property.
        /// </summary>
        /// <param name="context">
        /// An invocation context.
        /// </param>
        /// <param name="name">
        /// The name of a property.
        /// </param>
        public static void ClearProperty(this InvocationContext context, string name)
        {
            context.GetPropertyBag().ClearProperty(name);
        }

        #endregion

        #region PropertyBag Internal

        internal class PropertyBag : PropertyBagBase
        {
        }

        #endregion

        #region PropertyBag Private

        private static PropertyBag GetPropertyBag(this InvocationContext context)
        {
            Ensure.NotNull(context, "context");
            return context.GetApiService<PropertyBag>();
        }

        #endregion
    }
}