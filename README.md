# Sigm@7-test

## Question 1
The GIS server has a process which generates packages of data for the mobile GIS viewer
client to download, effectively refreshing the data on the client device. There are 260 mobile
client users, and each user can run the “Update Datasets” application from their laptop when
connected to the LAN. The “Update Datasets” application will copy the appropriate packages
from the hard disk on the GIS server to the laptop, and decompress the data, replacing the
existing datasets.
Our customer would like a report to be generated listing the date and time that each mobile
user last downloaded a data package from the server. The report should list the user name,
computer name, and the date and time that the user most recently downloaded a package of
data from the server.

We have the following constraints:
• 
There is no database server installed on the GIS server, therefore it is not
possible to store these details within a server database.
• 
The report should be generated when the customer selects the “Regenerate
Mobile User Report” command from a newly developed component that will run
on the server (overwriting the previous report if one exists).
• 
The report file should be generated at a fixed location on the GIS server hard
disk.
• 
The mobile client users and applications have access to the GIS server hard disk
when they are connected to the LAN.
Question:
Document the method(s) you would/could use to implement a solution to this requirement.
If more than one method is proposed, highlight the pros and cons of each proposal.
The documentation should be detailed enough to be passed to a colleague within the
development team to implement the solution.

## Question 2

Time complexity of my solution(removal part) will be O(n), it's possible to play with some optimisations as more efficient split or parallel treatment, but it will only influence asymptotic complexity. The spec is not clear regarding particular optimisations. One of my creado is premature optimization is the root of all evil, from Donald Knuth.
