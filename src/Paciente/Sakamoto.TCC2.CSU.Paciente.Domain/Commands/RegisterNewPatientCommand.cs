﻿using System;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects.Enums;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Commands
{
    public class RegisterNewPatientCommand : PatientCommand
    {
        public RegisterNewPatientCommand(string fullName,
            DateTime birthDate,
            Gender gender,
            string cpf,
            string phone)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            Cpf = new CPF(cpf);
            Phone = phone;

            //AggregateId = Id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPatientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }


}