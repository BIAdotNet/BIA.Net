// <copyright file="MemberDto.cs" company="MyCompany">
//     Copyright (c) MyCompany. All rights reserved.
// </copyright>

namespace MyCompany.BIATemplate.Domain.Dto.User
{
    using System.Collections.Generic;
    using MyCompany.BIATemplate.Domain.Dto.Bia;

    /// <summary>
    /// The DTO used for members.
    /// </summary>
    public class MemberDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user first name.
        /// </summary>
        public string UserFirstName { get; set; }

        /// <summary>
        /// Gets or sets the user last name.
        /// </summary>
        public string UserLastName { get; set; }

        /// <summary>
        /// Gets or sets the user login.
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Gets or sets the site id.
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public IEnumerable<MemberRoleDto> Roles { get; set; }
    }
}