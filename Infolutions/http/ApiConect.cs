﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infolutions.http
{
    public class ApiConect
    {
        private static readonly HttpClient httpClient = new HttpClient();
        readonly string baseurl = "https://www.tusitioexpress.cl/pa-infolutions/public/api";

        public async Task<ApiResponse> SendTransaction(string pathInfo, string body, string method = "POST")
        {
            string url = baseurl + pathInfo;

            Dictionary<string, string> headers = new()
            {
                /* No se requiere el envío de headers */
            };

            return await SendRequestAsync(url, body, method, headers);
        }

        public static async Task<ApiResponse> SendRequestAsync(string url, string body, string method = "POST", Dictionary<string, string>? headers = null)
        {
            var response = new ApiResponse();
            try
            {
                // Crear la solicitud HTTP
                HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(method), url);

                // Establecer el contenido si es un método POST o PUT
                if (method.Equals("POST", StringComparison.OrdinalIgnoreCase) ||
                    method.Equals("PUT", StringComparison.OrdinalIgnoreCase))
                {
                    request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                }

                // Agregar headers a la solicitud
                if (headers != null && headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                // Enviar la solicitud y obtener la respuesta
                HttpResponseMessage httpResponse = await httpClient.SendAsync(request);

                // Leer el contenido de la respuesta
                response.Code = (int)httpResponse.StatusCode;
                response.Message = httpResponse.ReasonPhrase;
                response.Data = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                response.Message = ex.Message;
                response.Code = 400; // Código de error genérico o personalizado
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 400;
            }

            return response;
        }
    }
}
