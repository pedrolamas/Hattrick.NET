# Hattrick.NET

A .NET component for communication with Hattrick.org using Hattrick's CHPP XML interface!

Project was started by [Pedro Lamas](http://twitter.com/pedrolamas). As of november 2009, [Stefan Kamphuis](https://twitter.com/superska) continued Pedro's work.

These are the implemented interfaces so far:

* Arena Details (chppxml.axd?file=arenaDetails)
* Log In and Log Out (chppxml.axd?file=login)
* Region Details (chppxml.axd?file=regionDetails)
* Connect (chppxml.axd?file=servers)

## Test Project

A unittesting project was added, which uses MbUnit as a testing framework. The Unittests project contains a file named config.xml, which should be copied over to the run directory of the test project (bin\debug in debug mode) and your login credentials for Hattrick should be in that file.

## Note:

The new log in interface requires a CHPP Id and Key for each application that can be retrieved at your CHPP Application page on Hattrick's site.
