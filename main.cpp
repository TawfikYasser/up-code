#include <iostream>
#include<ctime>
#include<time.h>
using namespace std;
#define Size 50
int main()
{

	time_t t ;
	struct tm *tmp ;
	char MY_TIME[Size];
	time( &t );

	//localtime() uses the time pointed by t ,
	// to fill a tm structure with the
	// values that represent the
	// corresponding local time.

	tmp = localtime( &t );

	// using strftime to display time
	strftime(MY_TIME, sizeof(MY_TIME), "%d-%b-%Y", tmp);

	cout<<"Formatted date & time : "<<MY_TIME ;

    /*
    time_t now = time(0);
    tm *ltm = localtime(&now);

    // print various components of tm structure.
    cout << "Year:" << 1900 + ltm->tm_year<<endl;
    cout << "Month: "<< 1 + ltm->tm_mon<< endl;
    cout << "Day: "<< ltm->tm_mday << endl;
    cout << "Time: "<< 5+ltm->tm_hour << ":";
    cout << 30+ltm->tm_min << ":";
    cout << ltm->tm_sec << endl;


    cout<<"Today is: "<< ltm->tm_mday <<"-"<<1+ltm->tm_mon<<"-"<<1900+ltm->tm_year <<endl;*/
    return 0;
}
