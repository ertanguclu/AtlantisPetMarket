using BusinessLayer.Abstract;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtlantisPetMarket.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        private readonly IMessageManager<AppDbContext, Message, int> _messageManager;
        private readonly UserManager<User> _userManager;


        public MessageController(UserManager<User> userManager, IMessageManager<AppDbContext, Message, int> messageManager)
        {
            _userManager = userManager;
            _messageManager = messageManager;
        }

        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var email = user.Email;

            var messageList = await _messageManager.GetListReceiverMessage(email);
            return View(messageList);
        }

        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var email = user.Email;

            var messageList = await _messageManager.GetListSenderMessage(email);
            return View(messageList);
        }

        [Route("MessageDetails/{id}")]
        public async Task<IActionResult> MessageDetails(int id)
        {
            var writerMessage = await _messageManager.FindAsync(id);
            if (writerMessage == null)
            {
                return NotFound();
            }

            var senderUser = await _userManager.FindByEmailAsync(writerMessage.Sender);
            if (senderUser == null)
            {
                return NotFound();
            }

            var isAdmin = await _userManager.IsInRoleAsync(senderUser, "Admin");

            ViewData["IsAdmin"] = isAdmin;

            return View(writerMessage);
        }

        [Route("ReceiverMessageDetails/{id}")]
        public async Task<IActionResult> ReceiverMessageDetails(int id)
        {
            var writerMessage = await _messageManager.FindAsync(id);
            if (writerMessage == null)
            {
                return NotFound();
            }

            // Admin rolünde olan kullanıcıyı bul
            var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");
            var adminEmail = adminUsers?.FirstOrDefault()?.Email;

            // Eğer alıcı admin ise, ReceiverName ve Receiver alanlarını düzenleyin
            if (writerMessage.Receiver == adminEmail)
            {
                writerMessage.ReceiverName = "Atlantis Pet Market";
                writerMessage.Receiver = "Atlantis Pet Market";
            }

            return View(writerMessage);
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage()
        {
            var adminUser = await _userManager.GetUsersInRoleAsync("Admin");
            string adminEmail = adminUser?.FirstOrDefault()?.Email;

            // Eğer bir admin varsa, emaili ViewBag'de sakla
            if (!string.IsNullOrEmpty(adminEmail))
            {
                ViewBag.ReceiverEmail = adminEmail;
            }
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(Message p)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Sender = mail;
            p.SenderName = name;


            var adminUserIds = await _userManager.GetUsersInRoleAsync("Admin");
            if (adminUserIds == null || !adminUserIds.Any())
            {
                return BadRequest("Admin rolüne sahip kullanıcı bulunamadı.");
            }

            string adminEmail = adminUserIds.FirstOrDefault()?.Email;

            if (!await _userManager.IsInRoleAsync(values, "Admin"))
            {
                p.Receiver = adminEmail;
                p.ReceiverName = "Atlantis Pet Market";
            }
            else
            {
                var usernamesurname = await _userManager.Users
                    .Where(x => x.Email == p.Receiver)
                    .Select(y => y.Name + " " + y.Surname)
                    .FirstOrDefaultAsync();

                p.ReceiverName = usernamesurname;
            }

            await _messageManager.AddAsync(p);
            return RedirectToAction("SenderMessage");
        }

        [Route("DeleteSenderMessage/{id}")]
        public async Task<IActionResult> DeleteSenderMessage(int id)
        {
            var message = await _messageManager.FindAsync(id);
            if (message != null)
            {
                await _messageManager.DeleteAsync(message);
            }

            return RedirectToAction("SenderMessage");
        }

        [Route("DeleteReceiverMessage/{id}")]
        public async Task<IActionResult> DeleteReceiverMessage(int id)
        {
            var message = await _messageManager.FindAsync(id);
            if (message != null)
            {
                await _messageManager.DeleteAsync(message);
            }

            return RedirectToAction("ReceiverMessage");
        }
    }
}
