﻿using Blazored.LocalStorage;
using Ecommerce.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Ecommerce.WebAssembly.Extensiones
{
    public class AutenticacionExtension : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AutenticacionExtension(ILocalStorageService localStorage)
        {
            _localStorageService = localStorage;
        }

        public async Task ActualizarEstadoAutenticacion(SesionDTO? sesionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;
            if (sesionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUsuario.Nombre),
                    new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                    new Claim(ClaimTypes.Role, sesionUsuario.Rol)
                },"JwtAuth"));
                
                await _localStorageService.SetItemAsync("sesionUsuario", sesionUsuario);

            }
            else
            {
                //Si pasamos NULL en el modelo DTO significa que cerraremos sesion
                claimsPrincipal = _sinInformacion;
                await _localStorageService.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _localStorageService.GetItemAsync<SesionDTO>("sesionUsuario");

            if(sesionUsuario == null)
            {
                return await Task.FromResult(new AuthenticationState(_sinInformacion));
            }

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUsuario.Nombre),
                    new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                    new Claim(ClaimTypes.Role, sesionUsuario.Rol)
                }, "JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));

        }
    }
}
