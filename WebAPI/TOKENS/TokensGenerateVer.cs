using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

namespace WebAPI.TOKENS
{
    public static class TokensGenerateVer
    {

        public static Tokens TK()
        {


            Tokens token = new Tokens();


            SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qzu5fasfsafsaf154456_"));
        SigningCredentials Credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

        ClaimsIdentity Identity = new ClaimsIdentity(
            new Claim[]
            {
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            });

        JwtSecurityTokenHandler Handler = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor Descriptor = new SecurityTokenDescriptor()
            {

                Subject = Identity,
                SigningCredentials = Credentials,
                Expires = DateTime.Now.AddHours(2)
        };


            SecurityToken tok =  Handler.CreateToken(Descriptor);

            string Token = Handler.WriteToken(tok);

            token.text = Token;
            token.life = tok.ValidTo;

            return token;
        }
    }
}