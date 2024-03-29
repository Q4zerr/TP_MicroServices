﻿using Api.Vols.Datas.Entities;
using Api.Vols.Datas.Repository;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace Api.Vols.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {

        /// <summary>
        /// The flight repository
        /// </summary>
        private readonly IFlightRepository _flightRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightsController"/> class.
        /// </summary>
        /// <param name="flightRepository">The flight repository.</param>
        public FlightsController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        // GET: api/Flights
        [HttpGet]
        [ProducesResponseType(typeof(List<Flight>), 200)]
        public IActionResult GetFlights()
        {
            return Ok(_flightRepository.GetFlights());
        }

        // GET api/Flights/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Flight), 200)]
        public IActionResult GetFlightById(string id)
        {
            var flight = _flightRepository.GetFlightById(new ObjectId(id));

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        // POST api/Flights
        [HttpPost]
        [ProducesResponseType(typeof(Flight), 200)]
        public IActionResult CreateFlight([FromBody] Flight flight)
        {
            return Ok(_flightRepository.CreateFlight(flight));
        }

        // PUT api/Flights
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Flight), 200)]
        public IActionResult UpdateFlight(string id, [FromBody] Flight flight)
        {
            var checkFlight = _flightRepository.GetFlightById(new ObjectId(id));

            if (checkFlight == null)
            {
                return NotFound();
            }

            return Ok(_flightRepository.UpdateFlight(flight));
        }

        // DELETE api/Flights/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult DeleteFlight(string id)
        {
            var checkFlight = _flightRepository.GetFlightById(new ObjectId(id));

            if (checkFlight == null)
            {
                return NotFound();
            }

            var success = _flightRepository.DeleteFlight(new ObjectId(id));
            return Ok(success);
        }


        [HttpGet("{numeroVol}/siege/{nomSiege}")]
        [ProducesResponseType(typeof(Seat), 200)]
        public IActionResult GetSeatStatus(string numeroVol, string nomSiege)
        {
            var seat = _flightRepository.GetSeatStatus(numeroVol, nomSiege);

            if (seat == null)
            {
                return NotFound();
            }

            return Ok(seat);
        }

        // PUT api/Seat
        [HttpPut("{numeroVol}/{nomSiege}")]
        [ProducesResponseType(typeof(Seat), 200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateSeat(string numeroVol, string nomSiege, string statutSiege)
        {
            var seatStatut = _flightRepository.GetSeatStatus(numeroVol, nomSiege);

            if (seatStatut == null)
            {
                return NotFound(); // Si le siège n'est pas trouvé
            }

            // Mettre à jour le siège avec les nouvelles valeurs
            var updatedSeat = _flightRepository.UpdateSeat(numeroVol, nomSiege, statutSiege);

            // Renvoie le siège mis à jour en réponse
            return Ok(updatedSeat);
        }
    }
}
