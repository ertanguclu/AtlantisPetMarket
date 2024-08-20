using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AtlantisPetMarket.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        private readonly IMessageManager<AppDbContext, Message, int> _messageManager;
        private readonly UserManager<User> _userManager;
        public AdminMessageController(IMessageManager<AppDbContext, Message, int> messageManager, UserManager<User> userManager)
        {
            _messageManager = messageManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> ReceiverMessageList()
        {

            string userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized(); 
            }

           
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Unauthorized(); 
            }

            
            string userEmail = user.Email;

            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest("Kullanıcının e-posta adresi bulunamadı."); 
            }

            var messages = await _messageManager.GetListReceiverMessage(userEmail);

            return View(messages);
        }
        public async Task<IActionResult> SenderMessageList()
        {
            string userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized(); 
            }

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Unauthorized(); 
            }

            string userEmail = user.Email;

            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest("Kullanıcının e-posta adresi bulunamadı."); 
            }

            var messages = await _messageManager.GetListSenderMessage(userEmail);

            return View(messages);
        }
        public async Task<IActionResult> AdminMessageDetails(int id)
        {
            var values = await _messageManager.FindAsync(id);
            return View(values);
        }
        public async Task<IActionResult> AdminMessageDelete(int id)
        {
            var values = await _messageManager.FindAsync(id);
            await _messageManager.DeleteAsync(values);
            return RedirectToAction("SenderMessageList");
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminMessageSend(Message p)
        {
            string senderEmail = User.Identity.Name;

            if (string.IsNullOrEmpty(senderEmail))
            {
                return Unauthorized(); 
            }

            p.Sender = senderEmail;

            var senderUser = await _userManager.FindByEmailAsync(senderEmail);
            p.SenderName = senderUser.Name + " " + senderUser.Surname;

            var receiverUser = await _userManager.FindByEmailAsync(p.Receiver);
            p.ReceiverName = receiverUser.Name + " " + receiverUser.Surname;

            if (receiverUser == null)
            {
                return NotFound("Alıcı bulunamadı.");
            }

            await _messageManager.AddAsync(p);

            return RedirectToAction("SenderMessageList");

        }
    }
}
