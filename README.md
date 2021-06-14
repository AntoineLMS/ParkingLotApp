# ParkingLotApp

Console Application for the coding challenge (Moffet).

I have added cars (DriverID,RegistrationPlate) in order to test the application. 
The two fields are randomly generated. The DriverID is generated between 1 and 100, accepted if lower than 75.
I used a HashSet collection in the Parking in order to store the registration plates and ensure their unicity.

User inputs :

  c1 = Creates a car in the gate entry queue

  c2 = Creates a car in the gate exit queue

  e1 = Emergency button for Entry
  
  e2 = Emmergency button for Exit
  
  l = List the vehicule in the Parking Lot
  
  q = Quit the Program
  
Each gate is managed on a separate Thread that can be suspended when the emergency button is pressed.
The Parking Lot is subscribed to events raised by the gates when a car has passed the barrier
in order to update the list of cars it contains.
