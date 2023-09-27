#include "mainwindow.h"
#include "Images.h"
#include <QApplication>

int main(int argc, char *argv[])
{
   //Images img;
   //img.WriteToDisk();
    QApplication a(argc, argv);
    MainWindow w;
    w.show();
    return a.exec();

}
