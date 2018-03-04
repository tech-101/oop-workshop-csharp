Exercise 2
==========

Implement the class SmsHandlerImpl. The requirements are:

- It should be easy (and safe) to add new commands in the future.
- The commands should behave as follows:


Command​            Example Response​               Notes
----------------------------------------------------------------------------------------​
BALANCE​            1500​                           Returns your balance in EUR​
SEND-100-FFRITZ​    OK​                             Send 100 EUR to user with username FFRITZ​
SEND-500-FFRITZ​    ERR-INSUFFICIENT- FUNDS​        You don’t have enough money for the transfer​
SEND-100-MMOUSE​    ERR-NO-USER​                    No such user with username MMOUSE​
TOTALSENT-FFRITZ​   100​                            Returns the total amount sent to FFRITZ over the lifetime​
XYZ​                ERR-UNKNOWN-COMMAND​            Command isn’t understood by system​
