﻿using AirportTicketBooking.Utils;

namespace AirportTicketBooking.Classes;
public class User
{
    private static long _id = 0;
    private List<Ticket> tickets = [];

    public long Id { get; init; } = ++_id;
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public List<Ticket> Tickets { get => tickets; }

    public bool BookTicket(Ticket ticket)
    {
        tickets.Add(ticket);
        return true;
    }
    public Ticket? RemoveTicket(Ticket ticket)
    {
        return Tickets.Remove(ticket) ? ticket : null;
    }
    public UserRole Role { get; init; }

    public User()
    {
        this.Name = String.Empty;
        this.Email = String.Empty;
        this.Password = String.Empty;
        this.Role = default;

    }
    public User( string name, string email, string password, UserRole role)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public override string ToString()
    {
        return $"{Name}\n" +
            $"Your email: {Email}\n" +
            $"Your role: {Role}\n" +
            $"Your Tickets: {Tickets.ToString}";
    }
}

