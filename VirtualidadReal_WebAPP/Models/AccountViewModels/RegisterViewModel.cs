using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualidadReal_WebAPP.Data;

namespace VirtualidadReal_WebAPP.Models.AccountViewModels
{
    public class RegisterViewModel
    {

        public RegisterViewModel()
            {
            Roles = new List<SelectListItem>();
            //Roles.Add(new SelectListItem() { Value = "b9ba9eef-fe1d-4bfe-abf2-ed306b2ddf38", Text = "Administrador" });
            //Roles.Add(new SelectListItem() { Value = "b38f234f-f95b-4617-9115-ce6143b40b4c", Text = "Coordinador" });
            Roles.Add(new SelectListItem() { Value = "952487fc-8879-4159-a81d-17dbca330b13", Text = "Jugador" });
            Roles.Add(new SelectListItem() { Value = "31597196-9b3e-497a-bc81-05a734af3bb2", Text = "Invitado" });

        }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Display(Name ="Permisos")]
        [UIHint("List")]
        public List<SelectListItem> Roles { get; set; }
        public string Rol{ get; set; }

        
        ///trae los datos cargados de la table Roles
        ///Para los Usuario registrados en la pagina 
        //solo se va a permitir los Roles de (Invitado / Jugador )
        //Los demas roles se van a asignar por db

        //public void getRoles(ApplicationDbContext _context)
        //{
        //    var roles = from r in _context.identityRoles select r;
        //    var ListaRoles = roles.ToList();
        //    foreach (var data in ListaRoles)
        //    {
        //        Roles.Add(new SelectListItem { Value = data.Id, Text = data.Name });
        //    }
        //}

    }
}
