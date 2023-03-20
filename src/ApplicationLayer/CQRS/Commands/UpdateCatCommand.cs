﻿using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using MediatR;

namespace ApplicationLayer.CQRS.Commands
{
    public class UpdateCatCommand : IRequest<int>
    {
        public int CatId { get; set; }
        public CreateCatDto CreateCatDto { get; set; }
    }
}
