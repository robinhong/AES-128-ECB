
#include "test.h"

Test::Test(QWidget *parent)
    : QMainWindow(parent), ui(new Ui_Test)
{
    ui->setupUi(this);
}

Test::~Test()
{
    delete ui;
}

void Test::on_btnEncrypt_clicked()
{
    ui->txtEncrypted->setText(AesUtil::AesEncrypt(ui->txtData->text(), ui->txtKey->text()));
}

void Test::on_btnDecrypt_clicked()
{
    ui->txtDecrypted->setText(AesUtil::AesDecrypt(ui->txtEncrypted->text(), ui->txtKey->text()));
}
