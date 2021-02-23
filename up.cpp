#include <iostream>
#include<ctime>
#include<time.h>
#include <iomanip>
#include<unordered_map>
#include<algorithm>
using namespace std;
class Day
{
public:
    string date;
    int open, high, low, close;
    float avg;
};
const int ARRAY_SIZE = 4;
unordered_map<string, int> monthsMap;

// Function which initializes the monthsMap
void sort_months()
{
    monthsMap["Jan"] = 1;
    monthsMap["Feb"] = 2;
    monthsMap["Mar"] = 3;
    monthsMap["Apr"] = 4;
    monthsMap["May"] = 5;
    monthsMap["Jun"] = 6;
    monthsMap["Jul"] = 7;
    monthsMap["Aug"] = 8;
    monthsMap["Sep"] = 9;
    monthsMap["Oct"] = 10;
    monthsMap["Nov"] = 11;
    monthsMap["Dec"] = 12;
}

bool comp(Day a, Day b)
{
    // Comparing the years
    string str1 = a.date.substr(7, 5);
    string str2 = b.date.substr(7, 5);
    if (str1.compare(str2) != 0) {
        if (str1.compare(str2) > 0)
            return true;
        return false;
    }

    // Comparing the months
    string month_sub_a = a.date.substr(3, 3);
    string month_sub_b = b.date.substr(3, 3);

    // Taking numeric value of months from monthsMap
    int month_a = monthsMap[month_sub_a];
    int month_b = monthsMap[month_sub_b];
    if (month_a != month_b) {
        return month_a > month_b;
    }

    // Comparing the days
    string day_a = a.date.substr(0, 2);
    string day_b = b.date.substr(0, 2);
    if (day_a.compare(day_b) > 0)
        return true;
    return false;
}

string todayDate()
{
    time_t t ;
    tm *tmp ;
    char MY_TIME[50];
    time( &t );
    // localtime() uses the time pointed by t ,
    // to fill a tm structure with the
    // values that represent the
    // corresponding local time.
    tmp = localtime( &t );
    // using strftime to display time
    // Copies into ptr the content of format,
    // expanding its format specifiers into the corresponding values
    // that represent the time described in timeptr, with a limit of maxsize characters.
    strftime(MY_TIME, sizeof(MY_TIME), "%d %b %Y", tmp);

    return MY_TIME ;
}
//The following function to add the default data to the array
void defaultData(Day arr_days[])
{

    //Day 1
    arr_days[0].date = "19 Feb 2021";
    arr_days[0].open = 100;
    arr_days[0].high = 100;
    arr_days[0].low = 100;
    arr_days[0].close = 5;
    arr_days[0].avg = 0;
    //Day 2
    arr_days[1].date = "29 Jan 2021";
    arr_days[1].open = 100;
    arr_days[1].high = 100;
    arr_days[1].low = 100;
    arr_days[1].close = 10;
    arr_days[1].avg = 0;
    //Day 3
    arr_days[2].date = "28 Jan 2021";
    arr_days[2].open = 100;
    arr_days[2].high = 100;
    arr_days[2].low = 100;
    arr_days[2].close = 20;
    arr_days[2].avg = 0;
}



void calculateAVGClosingPrice(Day arr_days[])
{
    int sum = 0;
    for(int i = 0 ; i<ARRAY_SIZE ; i++)
    {
        sum += arr_days[i].close;
    }
    arr_days[ARRAY_SIZE-1].avg = (float)sum/ARRAY_SIZE;
}
int main()
{
    cout<<todayDate()<<endl;
    // Array with 4 days, each day has 6 parts [Date - Open - High - Low - Close - AVG]
    Day arr_days[ARRAY_SIZE];
    defaultData(arr_days);

    arr_days[3].date = todayDate();
    arr_days[3].open = 100;
    arr_days[3].high = 100;
    arr_days[3].low = 100;
    arr_days[3].close = 8;
    arr_days[3].avg = 0;

    calculateAVGClosingPrice(arr_days);

    cout<<"Before sorting"<<endl;
    cout<<"Date        - Open  - High  - Low  - Close  - AVG "<<endl;
    for(int i = 0 ; i<ARRAY_SIZE; i++)
    {
        cout<<arr_days[i].date<<" - "<<arr_days[i].open<<"   - "<<arr_days[i].high<<"   - "
            <<arr_days[i].low<<"  - "<<arr_days[i].close<<" - "<<setw(10)<<arr_days[i].avg<<endl;
    }

    sort_months();

    sort(arr_days, arr_days + ARRAY_SIZE, comp);
    cout<<"After sorting"<<endl;
        for(int i = 0 ; i<ARRAY_SIZE; i++)
    {
        cout<<arr_days[i].date<<" - "<<arr_days[i].open<<"   - "<<arr_days[i].high<<"   - "
            <<arr_days[i].low<<"  - "<<arr_days[i].close<<" - "<<setw(10)<<arr_days[i].avg<<endl;
    }
    return 0;
}
