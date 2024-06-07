using MySqlEngineServiceAuthen.AuthenModels;
using MySqlEngineServiceAuthen.MySqlServiceAuthen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace AuthEchecklistAPI.Controllers
{
    public class ValuesController : ApiController
    {
        IMySqlServiceAuthen _mySqlServicesAuthen;
        public ValuesController(IMySqlServiceAuthen serviceAuthen) 
        {
            _mySqlServicesAuthen = serviceAuthen;
        }

        [Route("api/Authen/Register")]
        public async Task<IHttpActionResult> Register([FromBody] EchecklistInputAuthentication user)
        {
            try
            {
                var result =  await _mySqlServicesAuthen.RegisterAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Authen/Login")]
        public async Task<IHttpActionResult> Login([FromBody] EChecklistInputLogIn eChecklistInputLogIn)
        {
            try
            {
                var result = await _mySqlServicesAuthen.LoginAsync(eChecklistInputLogIn);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Authen/Forgetpass")]
        public async Task<IHttpActionResult> ForgotPassword([FromBody] EchecklistForgetInput echecklistForgetInput)
        {
            try
            {
                await _mySqlServicesAuthen.EChecklisForgetPassWord(echecklistForgetInput);
                return Ok("Updated password successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
