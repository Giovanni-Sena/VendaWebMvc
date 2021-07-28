using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendaWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage ="{0} obrigatório!")] // Campo obrigatório
        [StringLength(60,MinimumLength =3,ErrorMessage ="{0} deve ser maior {2} e menor que {1}!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} obrigatório!")]
        [Display(Name ="Data")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} obrigatório!")]
        [EmailAddress(ErrorMessage ="Informe um e-mail valido!")]
        [Display(Name="E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório!")]
        [Range(100.00, 5000.00, ErrorMessage ="{0} deve ser entre {1} e {2}!")]
        [Display(Name ="Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Salary { get; set; }

        [Display(Name ="Departamento")]
        public Departamento Departamento { get; set; }
        [Display(Name ="Departamento")]
        public int DepartamentoId { get; set; }
        public ICollection<HistoricoDeVendas> Vendas { get; set; } = new List<HistoricoDeVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string name, DateTime birthDate, string email, double salary, Departamento departamento)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Salary = salary;
            Departamento = departamento;
        }

        public void AddVenda(HistoricoDeVendas histVendas)
        {
            Vendas.Add(histVendas);
        }

        public void RemoveVenda( HistoricoDeVendas histVendas)
        {
            Vendas.Remove(histVendas);
        }

        public double TotalDeVendas( DateTime inicial, DateTime final)
        {
            return Vendas.Where(histVendas => histVendas.Date >= inicial && histVendas.Date <= final).Sum( histVendas => histVendas.Amount);
        }
    }
}
