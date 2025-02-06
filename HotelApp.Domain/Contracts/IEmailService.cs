﻿namespace HotelApp.Domain.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
