<Query Kind="Expression" />

///						+---------------+
///						|  	  Crawl     |  ~900 sites (4k as goal)
///						+---------------+
///							/		 \
///						   /		  \
///						  /			   \
///		+---------------+				+---------------+
///		|  SimpleParse  |				|   SaveToDrive | (65Gig as ziped folder)
///		+---------------+				+---------------+
///				|	     \
///				|		   ------------
///				V		   			   \
///		+---------------+  				+---------------+
///		|   Recognise   |   			|   GetImages   | (~1Tb)
///		+---------------+   			+---------------+
///				|								|
///				|								|
///				V								V
///		+---------------+				+---------------+
///		|  SaveToDrive  |				|    Rescale    |
///		+---------------+				+---------------+
///				|								|
///				|								|
///				|								V
///				|						+---------------+
///				|						|  SaveToDrive  | (~350Gig after compression)
///				|						+---------------+
///				|					   /		
///				|		   ------------			
///				V		 /						
///		+---------------+				
///		|     Combine   |				
///		+---------------+			
///				|								
///				|								
///				V								
///		+---------------+  				+---------------+
///		|  CreateDbRep  | ----------->	|  SaveToFile   |
///		+---------------+				+---------------+
///				|	     
///				|		 
///				V		 
///		+----------------+
///		| SaveToDatabase |
///		+----------------+