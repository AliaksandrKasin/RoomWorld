﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Services;

namespace RoomWorld.Controllers
{
    [ApiController]
    public class MessageController : Controller
    {

        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("/get/dialogs/all")]
        [Authorize]
        public async Task<IActionResult> GetAllDialogs()
        {
            try
            {
                var dialogs = await _messageService.GetAllDialogsAsync();
                return Ok(dialogs);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("/get/messages")]
        [Authorize]
        public async Task<IActionResult> GetMessages(string email)
        {
            try
            {
                var messages = await _messageService.GetMessagesByEmailAsync(email);
                return Ok(messages);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}