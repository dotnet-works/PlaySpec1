Feature: SocialNet1 Tests




Scenario: Sample1_SocialNetwork1
   Given user navigates to "https://www.opensource-socialnetwork.org/demo"
   When navigate to socialnetwork page
   When switch to new tab
   When click on 'dob' element and enter birtdate as "20 Oct. 2000"
   Then verify birthdate should be in dd/mm/yyyy format
   When enter new user data
   When open new tab and navigate to "https://www.yopmail.com"
   When verify email confirmation

   


Scenario: VerifyDOB_SocialNetwork2
   Given user navigates to "https://www.opensource-socialnetwork.org/demo"
   When navigate to socialnetwork page
   When switch to new tab
   #When click on 'dob' element and enter birtdate as "20 October 2000"
   #When click on 'dob' element and enter birtdate as "20 Jan. 2000"
   #When click on 'dob' element and enter birtdate as "20 June 2000"
   When click on 'dob' element and enter birtdate as "01 Jan. 2011"


Scenario: ParseDateTime1
  
   When formattype1 yyyy-MM-dd "2000-04-27" string
   When formattype2 dd-MM-yyyy "27-04-2000" string2
   When formattype3
   When formattype4 "20 October 2000"
   
   #When formattype4 "20 Oct 2000"
#   When formattype2 "02-27-2000" string2
#
#   When some user "8 October 2001" string
#   When print the format datetime
#   When some user "2/27/2000" string2
#   #Given some user "01-11-2000" string

Scenario: ParseDateTime2
  When dateformat input1 is "20 Jan. 2000"
  When dateformat input1 is "20 March 2000"
  When dateformat input1 is "1 March 2000"
  When dateformat input2 is "4 March 2000"
  When dateformat input2 is "4 Dec. 2000"
  When dateformat input2 is "4 December 2000"
  When dateformat input2 is "01 Jan. 2005"
  When dateformat input2 is "01 January 2003"
  When dateformat input2 is "01 Jan 2011"
 