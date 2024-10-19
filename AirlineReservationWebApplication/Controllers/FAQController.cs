using AirlineReservationWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationWebApplication.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult FAQs()
        {
            var faqCategories = new List<FAQCategory>
        {
            new FAQCategory
            {
                CategoryName = "Flights",
                FAQs = new List<FAQ>
                {
                    new FAQ { Id = 1, Question = "How do I request a special meal for my flight?", Answer = "Most Low-cost carrier (LCC) airlines now charge for in-flight meals or no longer offer a meal service except for full-service airlines. You may have an option to place a meal request when you purchase tickets online or call the airline directly. Special meal requests must be made at least 24-hours before the scheduled departure. These requests are not guaranteed and are at the discretion of the airline." },

                    new FAQ { Id = 2,Question="How do I book an infant fare?", Answer = "Only one infant (Up to 24 months) is allowed to travel as a lap child per adult (over 18 years). Infants traveling internationally will be required to pay a percentage of the adult fare (in most circumstances), plus taxes and carry a paper ticket even though they are traveling on the adult's lap. Please contact our Customer Service team at+88-09617-111-***" },

                    new FAQ { Id = 3,Question="How do I select my seats?", Answer = "You can request seat assignments at the time of booking. When submitting traveler details during booking process, please select \"Seat Preference\" in the additional requests area." },


                    new FAQ { Id = 4, Question = "Why did the fare increase when I tried to book my flight?", Answer = "Infant fares are available..." },

                    new FAQ { Id = 5, Question = "Can I call Muslim Airline directly to make a booking?", Answer = "Yes. Muslim Airline offers phone assistance are ready to meet your travel needs. Please contact our Customer Service team at +88-09617-111-***" },

                    new FAQ { Id = 6, Question = "Can I make reservations for last minute travel?", Answer = "Yes you can book last minute travel using our website. However, Some bookings may require up to three business days to process, therefore you may not be able to book last minute travel online. However, you may contact our Customer Service team+88-09617-111-***" },

                    new FAQ { Id = 7, Question = "Can I make a reservation arriving into one city and returning from another?", Answer = "Yes. This is a multi-city option. Our booking engine allows you to search fares in many different ways such as flying into one city and returning from another. Please click on the \"Multiple Cities\" tab on the \"Flight Search\" screen to book your itinerary." },

                    new FAQ { Id = 8, Question = "What is the maximum number of travelers that I can book online in one reservation?", Answer = "You may book up to a total of nine passengers on a single reservation. If you have more than nine travelers, then you can book multiple reservation or call our Customer Service team at+88-09617-111-***" },

                    new FAQ { Id = 9, Question = "Are the airfares guaranteed?", Answer = "All airfares are subject to change without prior notice and are not guaranteed until payment has been received and tickets have been issued. In the unlikely event of a technical error causing an incorrect fare to be displayed, we reserve the right to advise you of the correct fare within three business days of your booking. You may choose to accept the new fare or cancel your booking. Please read more detailed information in the Terms and Conditions Agreement." },

                    new FAQ { Id = 10, Question = "How do I change an existing reservation?", Answer = "Please contact our Customer Service team at +88-09617-111-***. Please note that airlines charge a change fee per ticket, plus any difference in fare, depending on the flights you choose." }
                }
            },
            new FAQCategory
            {
                CategoryName = "Hotel and Car Rental",
                FAQs = new List<FAQ>
{
                    new FAQ { Id = 1, Question = "I made a hotel /car reservation online. Do I get a confirmation voucher?", Answer = "All online bookings for hotel and car rental services will generate a confirmation with the number assigned by the hotel or car rental company. For guarantee only reservations, we also strongly suggest that all arrangements be confirmed not less than 24 hours prior to departure." },

                    new FAQ { Id = 2, Question = "How do I add additional passengers to an existing air, or hotel booking?", Answer = "Adding a guest to the same hotel room can be done by calling our customer service desk at +88-09617-111-888. If you need to book an additional room for the guest, you may do so online as a new reservation." },

                    new FAQ { Id = 3, Question = "What do I do if the Hotel/Car Rental charges more than the amount in my reservation?", Answer = "The hotel/Car Rental company must honor the rate given to you when you made the reservation. You may use your reservation printout as evidence and get the hotel to rectify the amount that is being charged." },

                    new FAQ { Id = 4, Question = "Do online bookings require immediate payment?", Answer = "Yes, booking requires immediate payment if the booking is under cancellation policies and booking doesn’t require immediate payment if the booking is under free cancellation policies. Cancellation policies vary by property. However, before check in a customer has to pay Flight Expert in order to have the hotel facilities unless it’s mentioned as 'Pay at Hotel'." },

                    new FAQ { Id = 5, Question = "What should I do if I have problems checking in, or they can’t find my reservation?", Answer = "It’s a good idea to print the Flight Expert’s confirmation. Call us at +88-09617-111-888 immediately to resolve the issue on a priority base." }
                }
            },

            new FAQCategory
            {
                CategoryName = "Vacation Packages",
                FAQs = new List<FAQ>
                {
                    new FAQ { Id = 1, Question = "What is a vacation package?", Answer = "A vacation package is a combination of Hotel + Car or Flight + Hotel + Car + Sightseeing or Hotel + Sightseeing that give you access to special rates." },

                    new FAQ { Id = 2, Question = "What would be the benefits of a Flight Expert’s vacation package?", Answer = "By choosing to buy your vacation package through Flight Expert, you are saving time as well as money. You'll always get the lowest airfare on the participating airlines with the purchase of a Flight Expert’s vacation package. In addition, we negotiate discounted hotel and car rental rates and pass the savings to you." },

                    new FAQ { Id = 3, Question = "While making a booking, can I opt for my own choice of flight, hotel or car?", Answer = "Yes, you can. We bundle the options as per our proprietary technology which combines your required travel product based on price, location, and ratings. At any time before the booking is completed, you can pick and choose flights, hotels or cars to get the desired vacation package." }
                }
            },
            new FAQCategory
            {
                CategoryName = "Airport Transfers",
                FAQs = new List<FAQ>
                {
                    new FAQ { Id = 1, Question = "What is an airport transfer?", Answer = "It is your hired motor vehicle ride between a location and the airport for your trip. Transfers can be either one way or round-trip. For example, you can purchase car service between your home and the departure airport for your destination." },

                    new FAQ { Id = 2, Question = "How do I book an airport transfer for my trip?", Answer = "It is your hired motor vehicle ride between a location and the airport for your trip. Transfers can be either one way or round-trip. For example, you can purchase car service between your home and the departure airport for your destination." },

                    new FAQ { Id = 3, Question = "Do I have to pay tolls and a gratuity for my airport transfer?", Answer = "When you select an all-inclusive airport transfer, you need not worry about paying tolls and/or a gratuity since they are included in the total cost of your transfer. (A gratuity, or tip, is an amount of money that is given directly to the driver in appreciation of the service, and is typically based on a percentage of its total cost.) If, however, you choose an airport transfer that is only partially inclusive or is not inclusive, then you will have to pay either the tolls or the gratuity, or both when you receive the service." },

                    new FAQ { Id = 4, Question = "What should I do if I do not receive email confirmation of my airport transfer?", Answer = "If the email confirmation does not appear in your inbox or spam folder soon after you complete the booking, then contact our customer care at +88-09617-111-888 immediately. A customer care representative should be able to make sure you get a confirmation with all of the details of your service." }
                }
            },
            new FAQCategory
            {
                CategoryName = "Billings",
                 FAQs = new List<FAQ>
                 {
                            new FAQ { Id = 1, Question = "When can I expect my refund?", Answer = "When a reservation is cancelled the same day it was booked, funds for the airline portion are not collected. Any pending charges you may have seen would have been a 'pending hold' for verification. These funds will return to your available credit and will not reflect as a refund. This process normally takes from 15 - 20 business days, depending on your banking institutions procedures. Please note: Some prepaid credit card companies will hold pending authorizations for up to 30 days. If the airline rules allow for cancellation the day after booking, funds for the airline portion will be refunded within 20 – 30 business days. It will depend upon the airline(s) and your banking institution's policies. At times the refund will post before the charge is processed or may not appear on your current statement. Please contact your bank to verify the refund was received." },

                            new FAQ { Id = 2, Question = "Why do I have duplicate charges for the same trip on my credit card?", Answer = "If you are certain there are posted duplicate charges from Muslim Airline, please contact the Accounts Department for assistance at +88-09617-111-***." },

                            new FAQ { Id = 3, Question = "What are the credit card transaction and currency conversion fees?", Answer = "Unless otherwise specified, all prices are displayed and quoted in Bangladeshi Taka (BDT) and all charges made are in Bangladeshi Taka (BDT). If you are using a non-Bangladeshi credit card, you should check with your bank for details on currency conversion charges. Your non-Bangladeshi credit card may charge you a fee for processing purchases made in Bangladeshi Taka." },

                            new FAQ { Id = 4, Question = "The billing address for my credit card is outside Bangladesh. Can I book with you?", Answer = "We process reservations for customers with billing addresses in all countries worldwide. For Details call our customer support at +88-09617-111-***." }
                 }

            },
            new FAQCategory
            {
                CategoryName = "General",
                FAQs = new List<FAQ>
            {
                new FAQ { Id = 1, Question = "How long has Flight Expert been in business?", Answer = "Muslim Airline has been operating since 2016; however, its parent company has been in business since 1993 under the name of 'Makka Tours & Travels' and various other concerns." },

                new FAQ { Id = 2, Question = "How does Muslim Airline compare with other online travel sites?", Answer = "We feel our fares are competitive, and we present an unbiased listing of Fares; we are not affiliated to any single airline or large consortium as other Major Travel sites are." }
            }
            }
        };

            return View(faqCategories);
        }
    }
}
