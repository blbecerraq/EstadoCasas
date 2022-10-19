using CeldasCore.Enumerator;
using CeldasCore.Models;
using CeldasInfraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeldasInfraestructure.Implementation
{
    public class Status : IStatus
    {
        public Response CalculateValueCells(Request request)
        {
            Response response = new Response() { 
                Days = request.Days,
                Input = request.Houses
            };
            var count = request.Houses.Count;
            List<int> temporaryList = request.Houses;
            for (int i = 0; i < request.Days; i++)
            {
                List<int> calculationList = new List<int>();
                for (int j = 0; j < count; j++)
                {
                    var vecinoizquierdo = j == 0 ? 0 : temporaryList[j - 1];
                    var vecinoderecho = j == count - 1 ? 0 : temporaryList[j + 1];
                    calculationList.Add(vecinoizquierdo == vecinoderecho ? 0 : 1);
                }
                temporaryList = calculationList;
            }
            response.Output = temporaryList;
            return response;
        }
        public string ValidationRequest(Request request)
        {
            var message = string.Empty;
            List<int> intValidate = new List<int> { 1, 0 };
            if (request.Houses.Count != Convert.ToInt32(EnumHouse.NumberHouses))
            {
                return EnumHouse.NotComplyLength;
            }
            foreach (var item in request.Houses)
            {
                if (!intValidate.Contains(item))
                {
                    return EnumHouse.NotMeetAcceptedValues;
                }
            }

            return message;
        }
    }
}
