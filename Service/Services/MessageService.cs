﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Service.DTO;

namespace Service.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<Dialog> _dialogRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessageService(IRepository<Message> messageRepository, IRepository<Dialog> dialogRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _messageRepository = messageRepository;
            _dialogRepository = dialogRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddMessageAsync(Message message)
        {
            var dialog =
                (await _dialogRepository.GetAllAsync(x => x.Client.Email == message.UserFrom.Email, x => x.Messages))
                .FirstOrDefault();
            if (dialog != null)
            {
                dialog.Messages.Add(message);
            }
            else
            {
                dialog = new Dialog {Client = message.UserFrom, Messages = new List<Message>()};
                dialog.Messages.Add(message);
            }

            await _dialogRepository.UpdateAsync(dialog);
        }

        public async Task<IList<MessageViewModel>> GetAllDialogsAsync()
        {
            var dialogs = await (await _dialogRepository.GetAllAsync())
                .Include(x => x.Messages)
                .ThenInclude(x => x.UserFrom).ToListAsync();
            var listMessages = new List<Message>();
            foreach (var dialog in dialogs)
            {
                var lastMessage = dialog.Messages.LastOrDefault();
                if (lastMessage != null)
                {
                    listMessages.Add(lastMessage);
                }
            }

            return _mapper.Map<IList<MessageViewModel>>(listMessages);
        }
        public async Task<IList<MessageViewModel>> GetMessagesByEmailAsync(string email)
        {          
            var dialogs = (await _dialogRepository.GetAllAsync(x => x.Client.Email == email))
                .Include(x => x.Messages)
                .ThenInclude(x => x.UserFrom).FirstOrDefault();
         
            return _mapper.Map<IList<MessageViewModel>>(dialogs?.Messages);
        }
    }
}