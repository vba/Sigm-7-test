# Sigm@7-test

## Question 1
First of all, I would like to try to convince the stakeholder or product owner that "HDD storage" is far from being ideal for such kind of tasks. For security reasons and because that fact that file system storage is less transactional that I know. I would suggest you a cloud based storages as S3 from Amazon or even Bigtable. Let's omit technical choices details, we could argue about later, and let's introduce a notion of abstract storage (AS)instead of concrete file system solution.


Our AS is key/value store where data could be represented as following:

UserID -> Report(listing the user name, computer name, and the date and time that the user most recently downloaded a package of data from the server)

I would propose to build this system on top of HTTP/S stack. Implementing following scenarios:

- Client emits a get request, on server side we deliver the stream(datasets) and generate such report(depending on technical choice it can be done in sync or async way)

- Customer acts on "Regenerate Mobile User Report"(the right term would be get MU report), the component emits a get request with UserID for which on server side we deliver status 200 with appropriate report or 404 status when report does not exist for such user.

- No direct access is permitted to our AS(security reasons), only a http wrapper(ul list representation of AS content) can be provided.

For simplicity we can replace AS by in memory structure as Map/Dictionary, but for that we will need to persist it somewhere when our web server stops, and read it when web server starts. In term of scalability it's not ideal because we will need to think about replication.

## Question 2

Time complexity of my solution(removal part) will be O(n), it's possible to play with some optimisations as more efficient split or parallel treatment, but it will only influence asymptotic complexity. The spec is not clear regarding particular optimisations. One of my creado is premature optimization is the root of all evil, from Donald Knuth.
