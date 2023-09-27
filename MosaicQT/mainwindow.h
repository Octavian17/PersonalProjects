#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include<QFileDialog>
#include<QLabel>


QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT
    friend class TestMosaic;

public:

    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    std::vector<int> AverageColour(const QImage& image);
    float Distance(const std::vector<int>& rgb1,const std::vector<int>& rgb2);

    int xc, yc;

protected:
    void changeEvent(QEvent *e);

private slots:
    void on_selectImageButton_clicked();
    void on_pushButton_clicked();
    void on_imagesButton_clicked();
    void on_AddButton_clicked();
    void on_SubmitRes_clicked();
    void on_SubmitImgRes_clicked();
    void on_SaveButton_clicked();
    int getX();
    int getY();

 private:
  QImage mainImage;
  QImage mosaic;
  int x=-1, y=-1;
  bool checkB;
    Ui::MainWindow *ui;
};
#endif // MAINWINDOW_H
