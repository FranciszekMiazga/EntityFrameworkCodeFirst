using EFWebApplicationCodeFirst.DTO_s;
using EFWebApplicationCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFWebApplicationCodeFirst.Services
{
    public interface IDbService
    {
        IEnumerable GetDoctors();
        int PostDoctor(Doctor doctor);
        int PutDoctor(int IdDoctor, Doctor doctor);
        int DeleteDoctor(int IdDoctor);
        Tuple<ReturnedValues, IEnumerable> GetPrescription(int IdPrescription, GetPrescriptionResponse prescriptionResponse);
    }
    public enum ReturnedValues
    {
        DOCTOR_NOT_EXIST, PRESCRIPTION_NOT_EXIST, PATIENT_NOT_EXIST, EVERYTHING_OK
    }
    public class DatabaseService : IDbService
    {
        private readonly MainDbContext _context;

        public DatabaseService(MainDbContext context)
        {
            _context = context;
        }
        public IEnumerable GetDoctors()
        {
            return _context.Doctors.Select(e=>e);
        }

        public int PostDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return 1;
        }

        public int PutDoctor(int IdDoctor,Doctor doctor)
        {
            if (IdDoctor != doctor.IdDoctor)
                return 0;

            if (!IfDoctorExistInDb(IdDoctor))
                return -1;

            _context.Doctors.Update(doctor);
            _context.SaveChanges();

            return 1;
        }
        public int DeleteDoctor(int IdDoctor)
        {

            if (_context.Doctors.Where(e => e.IdDoctor == IdDoctor).Any())
            {
                Doctor doctor = _context.Doctors.Where(e => e.IdDoctor == IdDoctor).First();
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return 1;
            }
            else
                return 0;
        }
        private bool IfDoctorExistInDb(int IdDoctor)
        {
            var result = _context.Doctors.Where(e => e.IdDoctor == IdDoctor).Any();

            if (!result)
                return false;

            return true;
        }

        public Tuple<ReturnedValues, IEnumerable> GetPrescription(int IdPrescription, GetPrescriptionResponse prescriptionResponse)
        {
            var doctor = GetDoctorByData(prescriptionResponse);
            if (doctor == null)
                return new(ReturnedValues.DOCTOR_NOT_EXIST, "Doctor with that personal data not exist.");
            var patient = GetPatientByData(prescriptionResponse);
            if (patient == null)
                return new(ReturnedValues.PATIENT_NOT_EXIST, "Patient with that personal data not exist.");
            var prescription = GetPrescriptionMedByData(IdPrescription, prescriptionResponse);
            if (prescription == null)
                return new(ReturnedValues.PRESCRIPTION_NOT_EXIST, "Prescription list does not exist.");

            var result = _context.Prescriptions
                .Where(e => e.IdDoctor == doctor.IdDoctor &&
                e.IdPatient == patient.IdPatient && e.IdPerscription == prescription.IdPerscription);

            return new(ReturnedValues.EVERYTHING_OK, result);
        }
        private Doctor GetDoctorByData(GetPrescriptionResponse prescriptionResponse)
        {
            var res = _context.Doctors
                .Where(e => e.FirstName == prescriptionResponse.DoctorFirstName &&
                e.LastName == prescriptionResponse.DoctorLastName);
            if (res.Any()==false)
                return null;

            return res.First();
        }
        private Patient GetPatientByData(GetPrescriptionResponse prescriptionResponse)
        {
            var res = _context.Patients
                .Where(e => e.FirstName == prescriptionResponse.PatientFirstName &&
                e.LastName == prescriptionResponse.PatientLastName);
            if (res.Any() == false)
                return null;

            return res.First();
        }
        private Prescription GetPrescriptionMedByData(int IdPrescription,GetPrescriptionResponse prescriptionResponse)
        {
            var res = _context.Prescriptions
                .Include(e => e.Prescription_Medicaments)
                .Where(e => e.IdPerscription == IdPrescription);
            if (res.Any() == false)
                return null;

            return res.First();
        }
    }
}
