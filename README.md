transactionalrepositorypattern
==============================

This is a working example of the pattern that I wrote about [here](http://www.rosengren.me/blog/Transactional-repository-pattern/)

### Why a new pattern?
I should probably begin by saying that I have no idea if there is any prior art for this, this is something that I just came up with while building the back-end for a new application. It is meant to simplify making a sequence of repository calls from your busines logic while still having it transactional. It is yet to be fully battle tested but initial tests looks like it's working.

### Getting the example to run
-    Run the Database.sql file located in the root of the project (the project, not the solution)
-    Modify the DB connectionstring in the App.config
-    Run the application
-    Assert that there are two and not four rows in the Person table