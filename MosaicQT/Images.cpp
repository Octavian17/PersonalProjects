#include "Images.h"
#include <string>
#include <vector>
#include <algorithm>

#include "opencv2/core/core.hpp"
#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"

Images::Images(int &x, int &y)
 :xc(x), yc(y)
{

}

void Images::WriteToDisk() 
{
	std::vector<cv::String> fn;
    cv::glob("C:/Users/Octavian/Desktop/Mosaic++/MosaicQT/myList/*.jpg", fn, false);
	size_t count = fn.size();
	for (size_t i = 0; i < count; i++)
	{
		cv::Mat image= cv::imread(fn[i]);
		std::string name = std::to_string(i);
        std::string path = "C:/Users/Octavian/Desktop/Mosaic++/MosaicQT/myList_scaled/" + name +".jpg";
		Scale(image);
		cv::imwrite(path, image);
	}
}
void Images::Scale(cv::Mat& image)
{
    cv::resize(image, image, cv::Size(xc,yc));
}

