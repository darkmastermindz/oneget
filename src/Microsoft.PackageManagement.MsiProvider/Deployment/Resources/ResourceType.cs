﻿//---------------------------------------------------------------------
// <copyright file="ResourceType.cs" company="Microsoft Corporation">
//   Copyright (c) 1999, Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
// Part of the Deployment Tools Foundation project.
// </summary>
//---------------------------------------------------------------------

namespace Microsoft.PackageManagement.Msi.Internal.Deployment.Resources
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents either a standard integer resource type or a custom resource type name.
    /// </summary>
    internal class ResourceType
    {
        // Silence warnings about doc-comments
#pragma warning disable 1591

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType None => "#0";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType Cursor => "#1";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType Bitmap => "#2";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType Icon => "#3";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType Menu => "#4";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType Dialog => "#5";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType String => "#6";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType FontDir => "#7";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType Font => "#8";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType Accelerator => "#9";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType RCData => "#10";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType MessageTable => "#11";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType GroupCursor => "#12";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType GroupIcon => "#14";

        public static ResourceType Version => "#16";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType DialogInclude => "#17";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType PlugPlay => "#19";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType Vxd => "#20";

        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ani")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType AniCursor => "#21";

        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ani")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType AniIcon => "#22";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType Html => "#23";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static ResourceType Manifest => "#24";

#pragma warning restore 1591

        private string resourceType;

        /// <summary>
        /// Creates a new resource type from a string resource name.
        /// </summary>
        /// <param name="resourceType">String resource name,
        /// or an integer resource type prefixed by a #.</param>
        public ResourceType(string resourceType)
        {
            if (string.IsNullOrWhiteSpace(resourceType))
            {
                throw new ArgumentNullException("resourceType");
            }

            this.resourceType = resourceType;

            if (IsInteger && IntegerValue < 0)
            {
                throw new ArgumentOutOfRangeException("resourceType");
            }
        }

        /// <summary>
        /// Creates a new integer resource type.
        /// </summary>
        /// <param name="resourceType">Integer value of a well-known resource type.</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public ResourceType(int resourceType)
            : this("#" + resourceType)
        {
        }

        /// <summary>
        /// Gets a flag indicating whether the resource type is an integer type.
        /// </summary>
        public bool IsInteger => resourceType.StartsWith("#", StringComparison.Ordinal);

        /// <summary>
        /// Gets the integer value of the resource type, or -1 if the resource type is not an integer.
        /// </summary>
        public int IntegerValue
        {
            get
            {
                if (!IsInteger ||
                    !int.TryParse(resourceType.Substring(1), out int value))
                {
                    value = -1;
                }

                return value;
            }
        }

        /// <summary>
        /// Gets a string representation of the resource type.
        /// </summary>
        /// <returns>The custom resource name, or the name of a well-known resource type.</returns>
        public override string ToString()
        {
            if (IsInteger)
            {
                switch (IntegerValue)
                {
                    case 0: return "None";
                    case 1: return "Cursor";
                    case 2: return "Bitmap";
                    case 3: return "Icon";
                    case 4: return "Menu";
                    case 5: return "Dialog";
                    case 6: return "String";
                    case 7: return "FontDir";
                    case 8: return "Font";
                    case 9: return "Accelerator";
                    case 10: return "RCData";
                    case 11: return "MessageTable";
                    case 12: return "GroupCursor";
                    case 14: return "GroupIcon";
                    case 16: return "Version";
                    case 17: return "DialogInclude";
                    case 19: return "PlugPlay";
                    case 20: return "Vxd";
                    case 21: return "AniCursor";
                    case 22: return "AniIcon";
                    case 23: return "Html";
                    case 24: return "Manifest";
                }
            }

            return resourceType;
        }

        /// <summary>
        /// Tests whether one resource type equals another object.
        /// </summary>
        /// <param name="obj">Other object.</param>
        /// <returns>True if equal, else false.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ResourceType);
        }

        /// <summary>
        /// Tests whether one resource type equals another.
        /// </summary>
        /// <param name="otherType">Other resource type.</param>
        /// <returns>True if equal, else false.</returns>
        public bool Equals(ResourceType otherType)
        {
            return otherType != null && resourceType.Equals(otherType.resourceType, StringComparison.Ordinal);
        }

        /// <summary>
        /// Gets a hash code suitable for using the resource type as a dictionary key.
        /// </summary>
        /// <returns>Hash code based on the resource type string.</returns>
        public override int GetHashCode()
        {
            return resourceType.GetHashCode();
        }

        /// <summary>
        /// Implicitly converts a string to a ResourceType.
        /// </summary>
        /// <param name="resourceType">String resource type to convert.</param>
        /// <returns>ResourceType object.</returns>
        public static implicit operator ResourceType(string resourceType)
        {
            return new ResourceType(resourceType);
        }

        /// <summary>
        /// Explicitly converts a ResourceType to a string.
        /// </summary>
        /// <param name="resourceType">ResourceType object to convert.</param>
        /// <returns>The resource type string.</returns>
        /// <remarks>
        /// Unlike <see cref="ToString" />, this conversion does not return
        /// the common name of well-known integer resource types. Therefore,
        /// the returned string is suitable for passing directly to Win32
        /// resource APIs that accept resource type strings.
        /// </remarks>
        public static explicit operator string(ResourceType resourceType)
        {
            return resourceType.resourceType;
        }
    }
}