The following are a set of requests that can be made using Fiddler - http://www.fiddler2.com/fiddler2/


--Headers--
User-Agent: Fiddler
Host: localhost:60747
Content-Type:  application/json; odata=verbose --used when Posting an entity to an endpoint
Accept:  application/atom+xml;application/atomsvc+xml;application/xml;application/atom+xml (Note: this is the default behavior)
Accept: application/json;odata=verbose  -v3
Accept: application/json -v2
MaxDataServiceVersion: 2.0
MaxDataServiceVersion: 3.0

Note:  They are still working on JSON lite, so that metadata does not have to be passed, so you either have to set max version to 2.0 
which sends verbose by default, or specify odata=verbose along with content type to indicate verbose for v3.  Later, the default will not
return a 415, but instead will send a JSON lite response without the metadata.

http://localhost:63458/MasterDataService.svc/Patients(0) - 404 not found
http://localhost:63458/MasterDataService.svc/Patients/0 - 400 bad request
http://localhost:63458/MasterDataService.svc/Patients(1) - 200 ok [pulls back Todd Meinershagen]
http://localhost:63458/MasterDataService.svc/Patients(2) - 200 ok [pulls back Kalyan Das]
v3 but request application/json without verbose - 415 unsupported media type
http://localhost:63458/MasterDataService.svc/Patients(1)/FirstName [pulls back a projected field]
http://localhost:63458/MasterDataService.svc/$metadata [pulls back the metadata for this service - does not support anything other than application/atom+xml]
Note - show SetPageSizeRule so that only 2 patients are returned
Note - need to install the WCF Data Service 5.0 so that the add service reference picks up WCF Data Service v3 (5.0)
(http://www.microsoft.com/en-us/download/details.aspx?id=29306)
http://localhost:63458/MasterDataService.svc/Patients?$filter=Id%20gt%202 [pulls back patients with Id greater than 2]
http://localhost:63458/MasterDataService.svc/Patients?$orderby=LastName [pulls back partners in order of last name]
http://localhost:63458/MasterDataService.svc/Patients?$filter=LastName%20eq%20'Das' [pulls back one patient]
http://localhost:63458/MasterDataService.svc/Patients?$select=Id,LastName [pulls back projection with Id, LastName]
http://localhost:63458/MasterDataService.svc/Patients?$top=2&$skip=3 [will start with the 4 record and read the top 2]
http://localhost:63458/MasterDataService.svc/Patients?$inlinecount=allpages&$top=2&$skip=2 [give total count and skip 2 and take the 2 left]
http://localhost:63458/MasterDataService.svc/Patients/$count [returns a scalar number giving the count]
http://localhost:63458/MasterDataService.svc/Patients(4) with delete verb [response is 403 - forbidden]
http://localhost:63458/MasterDataService.svc/Patients(4) with delete verb - provided right [response 204 - no content]
http://localhost:63458/MasterDataService.svc/Patients with post and {"FirstName":"Jeff","LastName":"Brown"} [get 403 forbidden]
http://localhost:63458/MasterDataService.svc/Patients with post and {"FirstName":"Jeff","LastName":"Brown"} [201 created with a return of the entity]
http://localhost:63458/MasterDataService.svc/Patients(1)/Episodes - pulls back the Episodes for Patient with Id 1

http://localhost:63458/MasterDataService.svc/GetPatientsWithLastNameStartingWith?prefix='M' - example of service operation


--SQL for Data Set Up--
/*
insert into dbo.Patients (FirstName, LastName) values ('Todd', 'Meinershagen')
insert into dbo.Patients (FirstName, LastName) values ('Kalyan', 'Das')
insert into dbo.Patients (FirstName, LastName) values ('Mike', 'Faulkinbury')
insert into dbo.Patients (FirstName, LastName) values ('Darryl', 'Gebert')

select	*
from	dbo.Patients
*/

