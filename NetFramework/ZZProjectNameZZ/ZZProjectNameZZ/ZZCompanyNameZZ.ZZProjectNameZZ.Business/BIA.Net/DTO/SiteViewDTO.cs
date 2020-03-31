﻿namespace BIA.Net.Business.DTO
{
#pragma warning disable SA1210 // Using directives must be ordered alphabetically by namespace
    using ZZCompanyNameZZ.ZZProjectNameZZ.Model;
#pragma warning restore SA1210 // Using directives must be ordered alphabetically by namespace

    using BIA.Net.Business.DTO.Infrastructure;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

#pragma warning disable CS1591 // Missing XML Comment
#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1402 // File may only contain one single class
    public class SiteViewDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        [Required]
        public int SiteId { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        [Required]
        public int ViewId
        {
            get { return View != null ? View.Id : 0; }
            set { View = new ViewDTO() { Id = value }; }
        }

        [Required]
        public ViewDTO View { get; set; }
    }

    public class SiteViewMapper : MapperBase<SiteView, SiteViewDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public override Expression<Func<SiteView, SiteViewDTO>> SelectorExpression
        {
            get
            {
                return p => new SiteViewDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION
                    ////ECC/ END CUSTOM CODE SECTION
                    SiteId = p.SiteId,
                    IsDefault = p.IsDefault,
                    View = (p.View == null) ? null : new ViewDTO()
                    {
                        Id = p.View.Id,
                        TableId = p.View.TableId,
                        Name = p.View.Name,
                        Description = p.View.Description,
                        Preference = p.View.Preference,
                        ViewType = (TypeOfView)p.View.ViewType,
                    }
                };
            }
        }

        public override void MapToModel(SiteViewDTO dto, SiteView model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION
            ////ECC/ END CUSTOM CODE SECTION
            model.SiteId = dto.SiteId;
            model.IsDefault = dto.IsDefault;
            model.ViewId = (dto.View == null) ? 0 : dto.View.Id;
            model.View = (dto.View == null) ? null : new View()
            {
                Id = dto.View.Id,
                TableId = dto.View.TableId,
                Name = dto.View.Name,
                Description = dto.View.Description,
                Preference = dto.View.Preference,
                ViewType = (int)dto.View.ViewType
            };
        }
    }
#pragma warning restore CS1591 // Missing XML Comment
#pragma warning restore SA1600 // Elements must be documented
#pragma warning restore SA1402 // File may only contain one single class
}