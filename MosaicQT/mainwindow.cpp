#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "Images.h"
#include <QtMath>
#include <QFile>
#include <QTextStream>
#include <memory>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
     ui->setupUi(this);
     QImage pix("C:/Users/Octavian/Desktop/Mosaic++/MosaicQT/TestImages/Waiting");
     pix= pix.scaled(500,500);
     ui->label_pic->setPixmap(QPixmap::fromImage(pix));
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::changeEvent(QEvent *e)
{
    QMainWindow::changeEvent(e);
    switch(e->type()){
    case QEvent::LanguageChange:
        ui->retranslateUi(this);
        break;
       default:
        break;

    }
}

std::vector<int> MainWindow::AverageColour(const QImage& image)
{
    int pixelCount = 0, b = 0, g = 0, r = 0;
        for (int index1 = 0;index1 < image.height(); index1++)
        {
             QRgb *pixels=(QRgb *) image.scanLine(index1);
             for (int index2 = 0; index2 < image.width(); index2++)
             {
                 pixelCount++;
                 QRgb pixel=pixels[index2];
                 r+=qRed(pixel);
                 g+=qGreen(pixel);
                 b+=qBlue(pixel);
             }

        }

    std::vector<int>rgb;
    rgb.push_back(r / pixelCount);
    rgb.push_back(g / pixelCount);
    rgb.push_back(b / pixelCount);
    return rgb;
}

float MainWindow::Distance(const std::vector<int>& rgb1,const std::vector<int>& rgb2)
{
    return sqrt(pow((rgb1[0] - rgb2[0]), 2) +
        pow((rgb1[1] - rgb2[1]), 2) +
        pow((rgb1[2] - rgb2[2]), 2));
}

void MainWindow::on_selectImageButton_clicked()
{

    //Code for open the picture file
    QFileDialog dialog(this);
    dialog.setNameFilter(tr("Images (*.png *.jpg *.jpeg)"));
    dialog.setViewMode(QFileDialog::Detail);
    QString fileName = QFileDialog::getOpenFileName(this,
           tr("Open Images"), "C:/Users/Octavian/Desktop/Mosaic++/MosaicQT", tr("Image Files (*.png *.jpg *.jpeg)"));
    //Select and show the picture file
    if(!fileName.isEmpty())
    {
         QImage image(fileName);
         if(x!=-1&&y!=-1)
             image=image.scaled(x,y);
         else
              image=image.scaled(500,500);
        ui->label_pic->setPixmap(QPixmap::fromImage(image ));
        mainImage=image;
    }
}

void MainWindow::on_imagesButton_clicked()
{
    QFile file("C:/Users/Octavian/Desktop/Mosaic++/MosaicQT/AverageColour.txt");
    if (!file.open(QIODevice::WriteOnly | QIODevice::Text))
            return;
    QTextStream out(&file);
    const QString folderPath = QFileDialog::getExistingDirectory(this, tr("C:/Users/Octavian/Desktop/Mosaic++/MosaicQT"));
    if(!folderPath.isEmpty())
    {
        QDir dir(folderPath);
        QStringList filter;
        filter << QLatin1String("*.png");
        filter << QLatin1String("*.jpeg");
        filter << QLatin1String("*.jpg");
        dir.setNameFilters(filter);
        QFileInfoList filelistinfo = dir.entryInfoList();
        QStringList fileList;
        foreach (const QFileInfo &fileinfo, filelistinfo) {
            QString imageFile = fileinfo.absoluteFilePath();
            QImage scaled_image(imageFile);
            std::vector<int> rgb(AverageColour(scaled_image));
            out<<imageFile<<" "<<rgb[0]<<" "<<rgb[1]<<" "<<rgb[2]<<"\n";
        }
}
    file.close();
}

void MainWindow::on_pushButton_clicked()
{
    QImage mos(500, 500, QImage::Format_ARGB32);
    mosaic=mos;
    if(x!=-1&&y!=-1)
        mosaic=mosaic.scaled(x,y);
    int index1=0, index2=0, n=0, m=0;
    if(!checkB)
    {
        xc=10;
        yc=10;
    }

    Images imgs(xc, yc);
    imgs.WriteToDisk();
    while(n<mainImage.height())
    {
       QImage Square(xc, yc, QImage::Format_RGB32);

        for(index1=n;index1<xc+n;index1++)
        {
         QRgb *pixels=(QRgb *)mainImage.scanLine(index1);

         for(index2=m;index2<yc+m;index2++)
          {
             QRgb pixel=pixels[index2];
             Square.setPixel(index2-m,index1-n,pixel);
          }

         }


        QFile file("C:/Users/Octavian/Desktop/Mosaic++/MosaicQT/AverageColour.txt");
        if (!file.open(QIODevice::ReadOnly | QIODevice::Text))
                return;

        std::vector<int> rgb1(AverageColour(Square));
        std::vector<int> rgb2;
        QString imagePath;
        float min=999999;
            QTextStream in(&file);
            while (!in.atEnd()) {
                QString line = in.readLine();
                QStringList list=line.split(" ");
                QString path=list[0];

                for(int index=1;index<list.size();index++)
                {

                    std::string avg=list[index].toLocal8Bit().constData();
                    rgb2.push_back(std::stoi(avg));
                }
                float d=Distance(rgb1,rgb2);
                if(d<min)
                {
                    imagePath=path;
                    min=d;
                }
                rgb2.clear();
            }
        QImage Similar(imagePath);




        for(int index3=0;index3<xc;index3++)
        {
            QRgb *pixels=(QRgb *)Similar.scanLine(index3);
            for(int index4=0;index4<yc;index4++)
            {
                QRgb pixel=pixels[index4];
                mosaic.setPixel(index4+m,index3+n,pixel);
            }


        }





         m+=yc;
        if(m==mainImage.width())
        {
            m=0;
            n+=xc;
        }



    }
    ui->label_pic->setPixmap(QPixmap::fromImage(mosaic));


}

void MainWindow::on_AddButton_clicked()
{
    QFileDialog dialog(this);
    dialog.setNameFilter(tr("Images (*.png *.jpg *.jpeg)"));
    dialog.setViewMode(QFileDialog::Detail);
     QFileDialog::getOpenFileName(this,
           tr("Open Images"), "C:/Users/Octavian/Desktop/Mosaic++/MosaicQT", tr("Image Files (*.png *.jpg *.jpeg)"));
}

void MainWindow::on_SubmitRes_clicked()
{
    QString str1 = ui->lineEdit1->text();
    QString str2 = ui->lineEdit2->text();
    x=str1.toInt();
    y=str2.toInt();
}

void MainWindow::on_SubmitImgRes_clicked()
{
    checkB=true;
    QString str1 = ui->lineEdit3->text();
    QString str2 = ui->lineEdit4->text();
    xc=str1.toInt();
    yc=str2.toInt();
}

void MainWindow::on_SaveButton_clicked()
{
    QString fileName = QFileDialog::getSaveFileName(this, tr("Save Image File"),
                                                    QString(),
                                                    tr("Images (*.jpg *.png  *.jpeg)"));
    if (!fileName.isEmpty())
    {
      mosaic.save(fileName);
    }
}

int MainWindow::getX()
{
    return x;
}
int MainWindow::getY()
{
    return y;
}
