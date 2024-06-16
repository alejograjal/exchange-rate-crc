# exchange-rate-crc
Simple API to get exchange rates for the all the bank institutions.

This API reads the BCCR page [Tipos de cambio anunciados en ventanilla por los intermediarios cambiarios](https://gee.bccr.fi.cr/indicadoreseconomicos/Cuadros/frmConsultaTCVentanilla.aspx) and present information over this [url](https://exchange-rate-crc.onrender.com/values).

Only contains one single endpoint `/values` and accept to filter queries:
  - bankentity: string with name of the entity => ("Banco de Costa Rica", "Banco Nacional de Costa Rica", "Banco Popular y de Desarrollo Comunal", "Banco BAC San José S.A.", "Banco BCT S.A.
Banco Cathay de Costa Rica S.A.", "Banco CMB","Banco Davivienda (Costa Rica) S.A", "Banco General (Costa Rica) S.A.", "Banco Improsa S.A.", "Banco Lafise S.A.", "Banco Promérica S.A.", "Banco Scotiabank de Costa Rica S.A.", "Prival Bank (Costa Rica) S.A", "Financiera Cafsa S.A.", "Financiera Comeca S.A.", "Financiera Desyfin S.A.", "Financiera MultiMoney S.A.", "Grupo Mutual Alajuela - La Vivienda de Ahorro y Préstamo", "Mutual Cartago de Ahorro y Préstamo", "Coope-ANDE N°1 R.L.", "Coopecaja R.L.", "Coopemep R.L.", "Cooperativa COOCIQUE R.L.", "Cooperativa Coopealianza R.L.", "Cooperativa CREDECOOP R.L.", "Cooperativa Nacional de Educadores R.L. (COOPENAE)", "Cooperativa San Marcos R.L.", "Coopeservidores R.L.", "Airpak Casa de Cambio", "ARI Casa de Cambio Internacional S.A.", "Casa de Cambio Global Exchange", "Casa de Cambio Teledolar S. A.", "BCT Valores, Puesto De Bolsa, S.A.", "BN Valores S.A.", Puesto de Bolsa", "Mercado Valores de Costa Rica Puesto de Bolsa", "PB Inversiones SAMA", "Popular Valores", "Puesto de Bolsa") 
  - entityType: string with name of the entity type => ("Bancos públicos", "Bancos privados", "Financieras", "Mutuales de Vivienda", "Cooperativas", "Casas de Cambio", "Puestos de Bolsa") 

