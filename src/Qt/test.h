#pragma once
#include "ui_test.h"
#include <QMainWindow>
#include "aesutil.h"

class Test : public QMainWindow {
    Q_OBJECT
    
public:
    Test(QWidget* parent = nullptr);
    ~Test();

private slots:
    void on_btnEncrypt_clicked();
    void on_btnDecrypt_clicked();

private:
    Ui_Test* ui;
};