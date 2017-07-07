<?php
use PHPUnit\Framework\TestCase;
// require (__DIR__. '/../Controller/Registration.php');
// require (__DIR__. '/../Model/config.php');
require (__DIR__. '/../Controller/dbConnect.php');
require (__DIR__. '/../Controller/Search.php');
require (__DIR__. '/../Controller/CreateSubmissionPortal.php');
// include ('Registration.php');

class LoginTest extends TestCase
{
     
    protected $db;
    protected $in_store;
  //   protected $dbd;
	 // //$db = new Controller\Registration;
	 public function setUp(){
	 	$this->create_portal = new CreateSubmissionPortal();
	 	$this->in_store = new Search();
    	$this->db = new dbConnect();
    	// $this->dbd = new Registration();	
	 }

	public function testThatWeCanLoginSuccessfully()
	{
		$emailid = "kidus@kidus.com";
		$password = "kidus123";
		$role = 1;

		//$user = new \Controller\login;
		//$user->setFirstName("KidusMT");
		$this->assertTrue($this->db->Login($emailid, $password, $role));
	}

	public function testThatIfUserRegisterToOurDatabaseSuccesfully()
	{
		$emailid = "amante@amante.com";
		$password = "buli123145";
		$role = 1;
		$username = "AmanteD";

		$this->assertTrue($this->db->Register($username,$emailid,$password,$role));
	}

	public function testSearchingBookFromTheDatabase()
	{
		
		$title = "Software Engineering";
		$this->assertEquals($title,$this->in_store->SearchBook($title));
	}

	public function testForTeachersCreateAssingmentSubmitionPortalSuccessful()
	{
		$emailid = "yosef@abate.com";
		//$emailid = "nati@vnv.com";
		$PortalName = "University";
		$level = "3rd year";
		$start_date = "Jun 20,2017";
		$dead_line = "Jul 3,2017";

		$this->assertTrue($this->create_portal->CreateSubmissionPortalMothod($emailid,$PortalName,$level,$start_date,$dead_line));
	}

	//Integeration Testing for Not letting user enter with out he is a registered user
	public function testIntegerationForTheLoginAndRegisteration()
	{
		// $emailid = "amante@amante.com";
		// $password = "buli123145";
		// $role = 1;
		$emailid = "kidus@kidus.com";
		$password = "kidus123";
		$role = 1;
		$username = "AmanteD";

		$this->assertTrue($this->db->Register($username,$emailid,$password,$role));
		$this->assertTrue($this->db->Login($emailid, $password, $role));
	}

	//Integeration Testing for not letting them post with out They are with a role of a Teacher
	public function testIntegerationForTeachersCreateAssingmentSubmitionPortalSuccessful()
	{
		$username = "Yosef Abate";
		$emailid = "yosef@abate.com";
		$password = "yosef123";
		$role = 2;
		//$emailid = "nati@vnv.com";
		$PortalName = "University";
		$level = "3rd year";
		$start_date = "Jun 20,2017";
		$dead_line = "Jul 3,2017";

		$this->assertFalse($this->db->Register($username,$emailid,$password,$role));
		$this->assertTrue($this->db->Login($emailid, $password, $role));
		$this->assertTrue($this->create_portal->CreateSubmissionPortalMothod($emailid,$PortalName,$level,$start_date,$dead_line));
	}

	public function testIntegarationForUserSearchIfHeIsARegisteredUser()
	{

		$username = "Android";
		$emailid = "kidus@kidus.com";
		$password = "kidus123";
		$role = 1;//role for highschool student
		$title = "Operating System";

		$this->assertTrue($this->db->Register($username,$emailid,$password,$role));
		$this->assertTrue($this->db->Login($emailid, $password, $role));
		$this->assertEquals($title,$this->in_store->SearchBook($title));
	}
}
