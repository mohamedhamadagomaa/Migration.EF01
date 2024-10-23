# Moigration.EF
In this App 8 operations 
1- creation of Database and migration In SetupEfCoreModel project 
 - >which contain my class which present my only table (Wallet) -> table(Wallets)
   >AppDbcontext project which inherit from Dbcontext class in Entity framwork And create a Wallets prop which reprsents a table Then create a OnConfiguring method which sort the connection string on it from my json file And sort it In variable (constr)
   >Then use sqlserver To connect with the database
  
