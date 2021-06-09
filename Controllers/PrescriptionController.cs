using EFWebApplicationCodeFirst.DTO_s;
using EFWebApplicationCodeFirst.Models;
using EFWebApplicationCodeFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFWebApplicationCodeFirst.Controllers
{
    [Route("api/prescription")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly MainDbContext _context;
        private IDbService _dbservice;

        public PrescriptionController(MainDbContext context, IDbService dbservice)
        {
            _context = context;
            _dbservice = dbservice;
        }
        [HttpGet("{IdPrescription}")]
        public IActionResult GetPrecription(int IdPrescription,GetPrescriptionResponse prescriptionResponse)
        {
            var res = _dbservice.GetPrescription(IdPrescription, prescriptionResponse);
            if (res.Item1.Equals(ReturnedValues.DOCTOR_NOT_EXIST) ||
                res.Item1.Equals(ReturnedValues.PATIENT_NOT_EXIST) ||
                res.Item1.Equals(ReturnedValues.PRESCRIPTION_NOT_EXIST))
            {
                return NotFound(res.Item2.ToString());
            }
            return Ok(res.Item2.ToString());
        }
    }
}
