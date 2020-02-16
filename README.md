# SDET-Scripting-Test
Q4. Write a C# console application that will compare two large csv files (30MB each) and output the differences. Please add some unit tests as well to validate the implementation.
1 I have implemented using transport NSW data file (CSV) 

2 Copied data files to \DataFiles\Analysis-V1.csv and \DataFiles\Analysis-V2.csv 

3 Each data file size of 35 MB.

4 1st Column (Line Numbers - data chnages in V2 File) 									
100	  IWL_2d	938.115.64	10-E.938.115.64.B.8.57820877	City Circle via Town Hall		1	1160	IWL_2d	0
	    IWL_2e	938.115.64	10-E.938.115.64.B.8.57820877	City Circle via Town Hall		1	1160	IWL_2e	0
									
69777	CMB_2a	938.115.48	55AF.938.115.48.M.4.57822413	Schofields		0	11406	CMB_2a	0
	    CMB_2d	938.115.50	55AF.938.115.48.M.4.57822413	Schof		0	11410	CMB_2d	0
									
127050	ESI_2d	1396.119.16	600C.1396.119.16.T.8.58024420	Bondi Junction		1	24530	ESI_2d	0
	      ESI_2d	1396.119.16	600C.1396.119.16.T.8.58024420	Bondi Junction		1	24531	ESI_2d	0
									
222848	RTTA_REV	938.115.4	K712.938.115.4.H.8.57824817	Empty Train		1		RTTA_REV	0
	      RTTA_REV	938.115.4	K712.938.115.4.H.8.57824817	Empty Train		1		RTTA_REVE	1
									
369669	BMT_2	1397.121.2	W788.1397.121.2.V.4.57842027	Empty Train		1	17035	BMT_2	0
	      BMT_21	1397.121.21	W788.1397.121.2.V.4.57842027	Empty Train		1	17035	BMT_2	0
									
451931	OLY_2b	1396.119.28	L2BW.1396.119.28.T.4.58026192	Olympic Park		1	32236	OLY_2b	0
	      OLY_2b	1396.119.28	L2BW.1396.119.28.T.4.58026192	Sydney Olympic Park		1	32236	OLY_2b	0
        
5 After executing the program.cs file, the discrepencies (output file) is saved into a csv file and stored into \Output\testHH-MM.csv

Unit Testing is performed with the above outlined data.
