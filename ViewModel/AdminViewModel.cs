﻿using AirportTicketBooking.Model.Classes;
using AirportTicketBooking.Model.Repositories;
using AirportTicketBooking.Utils;

namespace AirportTicketBooking.ViewModel;

public class AdminViewModel
{
    private User _admin;
    private List<Flight> _flights = FlightRepository.GetAllFlights();
    public AdminViewModel(User admin)
    {
        this._admin = admin;
    }
    public List<Flight> FillterFlights(
        double? price,
        String? departureCountrie,
        String? destinationCountrie,
        DateTime? date,
        Airport? departureAirport,
        Airport? destinationAirport,
        FlightClassType? Class)
    {
        var tempFlights = _flights;
        if (departureCountrie != null)
            tempFlights = tempFlights.Where(flight => flight.DepartureCountry == (Countries)Enum.Parse(typeof(Countries), departureCountrie)).ToList();
        if (destinationCountrie != null)
            tempFlights = tempFlights.Where(flight => flight.DestinationCountry == (Countries)Enum.Parse(typeof(Countries), destinationCountrie)).ToList();
        if (date != null)
            tempFlights = tempFlights.Where(flight => flight.Time >= date).ToList();
        //Equality Comparer
        if (departureAirport != null)
            tempFlights = tempFlights.Where(flight => flight.DepartureAirport == departureAirport).ToList();
        if (destinationAirport != null)
            tempFlights = tempFlights.Where(flight => flight.DestinationAirport == destinationAirport).ToList();
        if (Class != null)
            tempFlights = tempFlights.Where(flight => flight.Class.Type == Class).ToList();
        if(price != null)
            tempFlights = tempFlights.Where(flight => flight.Class.Price == price).ToList();
        return tempFlights;

    }
}
