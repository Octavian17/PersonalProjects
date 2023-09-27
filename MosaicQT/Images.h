#pragma once
#include<iostream>
#include <vector>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
class Images
{
public:
    Images(int &x, int &y);
	void WriteToDisk(); 
	void Scale(cv::Mat& image);
private:
    int xc, yc;
};

