﻿namespace AutoAd.Persistence.Features.Commands.Brands.Delete
{
    public class DeleteBrandCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
