using JGBANK.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGBANK.Controllers
{
    [Route("JGBANK")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressInterface _addressInterface;
        

        public AddressController(IAddressInterface addressInterface)
        {
            _addressInterface = addressInterface;
            
        }
    }
}
