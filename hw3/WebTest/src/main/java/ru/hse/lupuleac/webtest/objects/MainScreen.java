package ru.hse.lupuleac.webtest.objects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import ru.hse.lupuleac.webtest.elements.ButtonElement;

public class MainScreen extends PageObject {

    private ButtonElement issueButton;

    public MainScreen(WebDriver driver) {
        super(driver);
        issueButton = new ButtonElement(driver, By.className("yt-header__create-btn"));
    }

    public void openIssuePage() {
        issueButton.click();
    }
}