# Backzauber – Auftragskondintorin

Blazor WebAssembly website for Backzauber, deployed to GitHub Pages.

## Configuring content

### Gallery (`wwwroot/data/gallery.json`)

Add, remove, or reorder images by editing this file. Each entry has:

```json
{
  "imagePath": "images/gallery-cake1.jpg",
  "alt":       "Description for screen readers",
  "title":     "Visible caption (hover overlay)",
  "category":  "Hochzeitstorten"
}
```

**`category`** controls which tab the image appears under on the Home page preview.
Available tab values: `Hochzeitstorten`, `Motivtorten`, `Macarons & Patisserie`, `Details`.
The full Galerie page shows all images regardless of category.

Place new image files in `wwwroot/images/` and reference them as `"images/your-file.jpg"` (no leading slash).

---

### Testimonials (`wwwroot/data/testimonials.json`)

Edit customer quotes freely. Each entry has:

```json
{
  "quote":  "Die Torte war traumhaft schön und hat alle Gäste begeistert!",
  "author": "Anna S."
}
```

Add as many entries as you like — they all appear in the Kundenstimmen section.

---

### Contact form

The contact form is powered by [web3forms](https://web3forms.com) and appears on both the **Home** page and the **Bestellung** page.

**Configuration is done inside `Components/ContactFormSection.razor`:**

| Hidden field     | Current value                                           | Purpose                                      |
|------------------|---------------------------------------------------------|----------------------------------------------|
| `access_key`     | `4d1ffb0d-4322-40c6-9d6b-e1580bc37ed5`                  | Your web3forms access key                    |
| `subject`        | `Neue Anfrage – Backzauber`                              | Subject line of the notification email       |
| `from_name`      | `Backzauber Website`                                     | Sender name in the notification email        |
| `redirect`       | `https://rotbarsch.github.io/patisserie/danke`           | Page shown after successful submission       |

After submitting, visitors are taken to the **`/danke`** page and can return home from there.

#### Spam protection (hCaptcha)

The form includes an hCaptcha widget (loaded automatically by the web3forms script).
To make hCaptcha mandatory server-side, log in to your web3forms dashboard and enable it:

1. Go to <https://app.web3forms.com>
2. Select your form
3. Enable **hCaptcha** as the spam-blocking method

Without this step the widget renders but submissions are not blocked server-side if the captcha is skipped.

---

## Development

```bash
dotnet run
# App runs at http://localhost:5030 (or next available port)
```

## Deployment

Deployment to GitHub Pages is handled automatically by `.github/workflows/deploy.yml` on every push to `main`.
The workflow patches `<base href>` to `/patisserie/`, copies `index.html` → `404.html` for SPA routing, and deploys the published output.
