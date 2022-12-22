﻿using AirBnb_Part_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirBnb_Part_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VicationController : ControllerBase
    {
        //--------------------------------------------------------------------------------------------------
        // # GET ALL VACATION                               
        //--------------------------------------------------------------------------------------------------

        // GET: api/<VixationController>
        [HttpGet("getAllVications")]
        public List<Vacation> Get()
        {
            return Vacation.Read();
        }
        //--------------------------------------------------------------------------------------------------
        // # GET VACATION  BY ID                             
        //--------------------------------------------------------------------------------------------------
        // GET api/<VixationController>/5

        [HttpGet("GetVacationByID/id/{id}")]
        public Vacation Get(int id)
        {

            List<Vacation> V = Vacation.Read();
            foreach (var item in V)
            {
                if (item.id == id)
                {
                    return item;
                }

            }
            return null;
        }
        //--------------------------------------------------------------------------------------------------
        // # GET VACATION BY DATES                               
        //--------------------------------------------------------------------------------------------------
        [HttpGet("getByDates/startDate/{startDate}/endDate/{endDate}")]
        public List<Vacation> getByDates(DateTime startDate, DateTime endDate)
        {
            List<Vacation> VList = Vacation.getByDatesOrders(startDate, endDate);
            
                if (VList.Count>=0)
                {

                    return VList;
                }

            
            return null;
        }

        //--------------------------------------------------------------------------------------------------
        // # INSERT VACATION                               
        //--------------------------------------------------------------------------------------------------
        // POST api/<VixationController>
        [HttpPost("Insert Vacation")]
        public int Post([FromBody] Vacation V)
        {
            return V.Insert(V);
        }

        //--------------------------------------------------------------------------------------------------
        // # UPDATE VACATION                               
        //--------------------------------------------------------------------------------------------------

        // PUT api/<VixationController>/5
        [HttpPut("Update Vication")]
        public IActionResult Put(int id, [FromBody] Vacation vacation)
        {
            vacation.id = id;
            int temp = vacation.UpdateVacation(vacation);
            if (temp > 0)
            {
                return Ok();
            }
            else

            {
                return NotFound("id " + id.ToString() + " was not update");
            }




        }
        //--------------------------------------------------------------------------------------------------
        // # DELETE VACATION                               
        //--------------------------------------------------------------------------------------------------
        // DELETE api/<VixationController>/5
        [HttpDelete("Delete Vacation By{id}")]
        public IActionResult Delete(int id)
        {
            Vacation v = new Vacation();
            int temp = v.DeleteVacation(id);
            if (temp > 0)
            {
                return Ok();
            }
            else

            {
                return NotFound("id " + id.ToString() + " was not found");
            }


        }
       






    }
}