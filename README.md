# VialSnap
*For some reason it isn't working on VS 2015. I build this app with VS 2017 Community Edition. Maybe you can try changing the version number in Web.Config file.
## User-Friendly Pharmaceutical Progressive Web App
### http://www.vialsnap.com
This app helps pharmacists and technicians manage their patient's perscriptions, organize the drug inventory, and make payments. 
I worked at CVS as a pharmacy technician and I didn't like their RxConnect System. Not only does their dull gray-bluish screen put you to 
sleep, but their system is frustrating, the user interface isn't friendly, the GUI is bad, and navigating it is tedious. 
Did you know that they don't use a mouse so they can calculate the employee's efficiency by recording the keystrokes? Well, I think that 
is very inefficient.
VialSnap will have a slick interface, but I want to recreate it in ASP.Net Core.

I named it Vialsnap because finally will technicians be able to do get their work done in a 'snap'. Vial is the orange container for the 
tablets and pills. So the our system is fast and effiecient opening one of those non-saftey caps on a vial.

The project has 2 Controllers. The Patient Controller and Pharmacy Controller. I made a one to many relation where I linked the patients with the medication they are taking. I also linked all the medications to the pharmacies and added a controlled substance to each one.
